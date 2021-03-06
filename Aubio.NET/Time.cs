﻿using JetBrains.Annotations;

namespace Aubio.NET
{
    [PublicAPI]
    public struct Time
    {
        public int Samples { get; }
        public float Seconds { get; }
        public float Milliseconds { get; }

        private Time(int sampleRate, int samples)
        {
            Samples = samples;
            Seconds = Converters.SamplesToSeconds(sampleRate, Samples);
            Milliseconds = Converters.SamplesToMilliseconds(sampleRate, samples);
        }

        public static Time FromSamples(int sampleRate, int samples)
        {
            return new Time(sampleRate, samples);
        }

        public static Time FromSeconds(int sampleRate, float seconds)
        {
            return new Time(sampleRate, Converters.SecondsToSamples(sampleRate, seconds));
        }

        public static Time FromMilliseconds(int sampleRate, float milliseconds)
        {
            return new Time(sampleRate, Converters.MillisecondsToSamples(sampleRate, milliseconds));
        }
    }
}