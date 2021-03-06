﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region File Description
//-----------------------------------------------------------------------------
// WaveFile.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion


namespace StreamFromFileSample
{
    public class WaveFile
    {
        private static double bytesToDouble(byte firstByte, byte secondByte)
        {
            // convert two bytes to one short (little endian)
            short s = (short)((secondByte << 8) | firstByte);
            // convert to range from -1 to (just below) 1
            return s / 32768.0;
        }

        // Returns left and right double arrays. 'right' will be null if sound is mono.
        public static int openWav(string filename, out double[] left, out double[] right)
        {
            byte[] wav = File.ReadAllBytes(filename);
            int samplesRate = wav[24] + (wav[25] << 8) + (wav[26] << 16) + (wav[27] << 24);
            // Determine if mono or stereo
            int channels = wav[22];     // Forget byte 23 as 99.999% of WAVs are 1 or 2 channels

            // Get past all the other sub chunks to get to the data subchunk:
            int pos = 12;   // First Subchunk ID from 12 to 16

            // Keep iterating until we find the data chunk (i.e. 64 61 74 61 ...... (i.e. 100 97 116 97 in decimal))
            while (!(wav[pos] == 100 && wav[pos + 1] == 97 && wav[pos + 2] == 116 && wav[pos + 3] == 97))
            {
                pos += 4;
                int chunkSize = wav[pos] + wav[pos + 1] * 256 + wav[pos + 2] * 65536 + wav[pos + 3] * 16777216;
                pos += 4 + chunkSize;
            }
            pos += 8;

            // Pos is now positioned to start of actual sound data.
            int samples = (wav.Length - pos) / 2;     // 2 bytes per sample (16 bit sound mono)
            if (channels == 2) samples /= 2;        // 4 bytes per sample (16 bit stereo)

            // Allocate memory (right will be null if only mono sound)
            left = new double[samples];
            if (channels == 2) right = new double[samples];
            else right = null;

            // Write to double array/s:
            int i = 0;
            while (pos < wav.Length)
            {
                left[i] = bytesToDouble(wav[pos], wav[pos + 1]);
                pos += 2;
                if (channels == 2)
                {
                    right[i] = bytesToDouble(wav[pos], wav[pos + 1]);
                    pos += 2;
                }
                i++;
            }

            return samplesRate;
        }

        // Returns left and right double arrays. 'right' will be null if sound is mono.
        //Performs down-sampling.
        public static int openWav(string filename, out double[] left, out double[] right, int samplesPerSec) //only mono
        {
            int jumps;
            if (samplesPerSec == 0)
            {
                right = null;
                left = null;
                return -1;
            }
            byte[] wav = File.ReadAllBytes(filename);
            int samplesRate = wav[24] + (wav[25] << 8) + (wav[26] << 16) + (wav[27] << 24);
            if(samplesPerSec>samplesRate)
            {
                right = null;
                left = null;
                return -1;
            }
            jumps = samplesRate / samplesPerSec;
            // Determine if mono or stereo
            int channels = wav[22];     // Forget byte 23 as 99.999% of WAVs are 1 or 2 channels

            // Get past all the other sub chunks to get to the data subchunk:
            int pos = 12;   // First Subchunk ID from 12 to 16

            // Keep iterating until we find the data chunk (i.e. 64 61 74 61 ...... (i.e. 100 97 116 97 in decimal))
            while (!(wav[pos] == 100 && wav[pos + 1] == 97 && wav[pos + 2] == 116 && wav[pos + 3] == 97))
            {
                pos += 4;
                int chunkSize = wav[pos] + wav[pos + 1] * 256 + wav[pos + 2] * 65536 + wav[pos + 3] * 16777216;
                pos += 4 + chunkSize;
            }
            pos += 8;

            // Pos is now positioned to start of actual sound data.
            int samples = (wav.Length - pos) / 2;     // 2 bytes per sample (16 bit sound mono)
            if (channels == 2) samples /= 2;        // 4 bytes per sample (16 bit stereo)

            // Allocate memory (right will be null if only mono sound)
            left = new double[(int)Math.Ceiling((double)samples/jumps)];
            if (channels == 2) right = new double[(int)Math.Ceiling((double)samples / jumps)];
            else right = null;

            // Write to double array/s:
            int i = 0;
            while (pos < wav.Length-1)
            {
                left[i] = bytesToDouble(wav[pos], wav[pos + 1]);
                pos += 2;
                if (channels == 2)
                {
                    right[i] = bytesToDouble(wav[pos], wav[pos + 1]);
                    pos += 4*jumps-2;
                }
                else
                {
                    pos += 2 * jumps-2;
                }
                
                i++;
            }
            return samplesRate/jumps;
        }
    }
}
