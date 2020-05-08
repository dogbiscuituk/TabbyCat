namespace TabbyCat.Tests.Models
{
    using NUnit.Framework;
    using System.Collections;

    public class SingalTestsData
    {
        /// <summary>
        /// Test data for case WaveType Constant.
        /// In general, the time value sampes the first period of the waveform, at one-eighth period intervals.
        /// The value obtained should always be equal to the amplitude.
        /// </summary>
        public static IEnumerable ConstantTestCases
        {
            get
            {
                yield return new TestCaseData(1, 4, 0 / 8f, 1);
                yield return new TestCaseData(2, 3, 1 / 8f, 2);
                yield return new TestCaseData(3, 2, 2 / 8f, 3);
                yield return new TestCaseData(4, 1, 3 / 8f, 4);
                yield return new TestCaseData(5, 0, 4 / 8f, 5);
                yield return new TestCaseData(6, 1, 5 / 8f, 6);
                yield return new TestCaseData(7, 2, 6 / 8f, 7);
                yield return new TestCaseData(8, 3, 7 / 8f, 8);
                yield return new TestCaseData(9, 4, 8 / 8f, 9);
            }
        }

        /// <summary>
        /// Test data for case WaveType RampDown.
        /// In general, the time value sampes the first period of the waveform, at one-eighth period intervals.
        /// </summary>
        public static IEnumerable RampDownTestCases
        {
            get
            {
                yield return new TestCaseData(1, 1, 0 / 8f, 0);
                yield return new TestCaseData(2, 1, 1 / 8f, -0.5f);
                yield return new TestCaseData(3, 1, 2 / 8f, -1.5f);
                yield return new TestCaseData(4, 1, 3 / 8f, -3);
                yield return new TestCaseData(5, 1, 4 / 8f, 5);
                yield return new TestCaseData(6, 2, 5 / 8f / 2, 4.5f);
                yield return new TestCaseData(7, 3, 6 / 8f / 3, 3.5f);
                yield return new TestCaseData(8, 4, 7 / 8f / 4, 2);
                yield return new TestCaseData(9, 5, 8 / 8f / 5, 0);
            }
        }

        /// <summary>
        /// Test data for case WaveType RampUp.
        /// In general, the time value sampes the first period of the waveform, at one-eighth period intervals.
        /// </summary>
        public static IEnumerable RampUpTestCases
        {
            get
            {
                yield return new TestCaseData(1, 1, 0 / 8f, 0);
                yield return new TestCaseData(2, 1, 1 / 8f, 0.5f);
                yield return new TestCaseData(3, 1, 2 / 8f, 1.5f);
                yield return new TestCaseData(4, 1, 3 / 8f, 3);
                yield return new TestCaseData(5, 1, 4 / 8f, -5);
                yield return new TestCaseData(6, 2, 5 / 8f / 2, -4.5f);
                yield return new TestCaseData(7, 3, 6 / 8f / 3, -3.5f);
                yield return new TestCaseData(8, 4, 7 / 8f / 4, -2);
                yield return new TestCaseData(9, 5, 8 / 8f / 5, 0);
            }
        }

        /// <summary>
        /// Test data for case WaveType Sine.
        /// In general, the time value sampes the first period of the waveform, at one-twelfth period intervals.
        /// There are also a few test times outside this interval.
        /// </summary>
        public static IEnumerable SineTestCases
        {
            get
            {
                yield return new TestCaseData(1, 1, 145 / 12f, 0.5f);
                yield return new TestCaseData(2, 1, -3 / 12f, -2);
                yield return new TestCaseData(3, 1, -2 / 12f, -2.59807634f);
                yield return new TestCaseData(4, 1, -1 / 12f, -2);
                yield return new TestCaseData(5, 1, 0 / 12f, 0);
                yield return new TestCaseData(6, 1, 1 / 12f, 3);
                yield return new TestCaseData(7, 1, 2 / 12f, 6.06217813f);
                yield return new TestCaseData(8, 1, 3 / 12f, 8);
                yield return new TestCaseData(9, 1, 4 / 12f, 7.79422855f);
                yield return new TestCaseData(10, 1, 5 / 12f, 5);
                yield return new TestCaseData(11, 1, 6 / 12f, 0);
                yield return new TestCaseData(12, 2, 7 / 12f / 2, -6);
                yield return new TestCaseData(13, 3, 8 / 12f / 3, -11.2583313f);
                yield return new TestCaseData(14, 4, 9 / 12f / 4, -14);
                yield return new TestCaseData(15, 5, 10 / 12f / 5, -12.9903812f);
                yield return new TestCaseData(16, 6, 11 / 12f / 6, -8);
                yield return new TestCaseData(17, 7, 12 / 12f / 7, 0);
                yield return new TestCaseData(18, 1, 13 / 12f, 9);
                yield return new TestCaseData(19, 1, 15 / 12f, 19);
                yield return new TestCaseData(2, 1, 145 / 12f, 1);
            }
        }

        /// <summary>
        /// Test data for case WaveType Square.
        /// In general, the time value sampes the first period of the waveform, at one-twelfth period intervals.
        /// </summary>
        public static IEnumerable SquareTestCases
        {
            get
            {
                yield return new TestCaseData(1, 1, -3 / 12f, -1);
                yield return new TestCaseData(2, 1, -1 / 12f, -2);
                yield return new TestCaseData(3, 1, 0 / 12f, 3);
                yield return new TestCaseData(4, 1, 1 / 12f, 4);
                yield return new TestCaseData(5, 1, 3 / 12f, 5);
                yield return new TestCaseData(6, 1, 5 / 12f, 6);
                yield return new TestCaseData(7, 1, 6 / 12f, -7);
                yield return new TestCaseData(8, 2, 7 / 12f / 2, -8);
                yield return new TestCaseData(9, 3, 9 / 12f / 3, -9);
                yield return new TestCaseData(10, 4, 11 / 12f / 4, -10);
                yield return new TestCaseData(11, 5, 12 / 12f / 5, 11);
                yield return new TestCaseData(12, 6, 13 / 12f / 6, 12);
                yield return new TestCaseData(100, 1, 145 / 12f, 100);
            }
        }

        /// <summary>
        /// Test data for case WaveType Triangle.
        /// In general, the time value sampes the first period of the waveform, at one-eighth period intervals.
        /// </summary>
        public static IEnumerable TriangleTestCases
        {
            get
            {
                yield return new TestCaseData(1, 1, 0 / 8f, 0);
                yield return new TestCaseData(2, 1, 1 / 8f, 1);
                yield return new TestCaseData(3, 1, 2 / 8f, 3);
                yield return new TestCaseData(4, 1, 3 / 8f, 2);
                yield return new TestCaseData(5, 1, 4 / 8f, 0);
                yield return new TestCaseData(6, 2, 5 / 8f / 2, -3);
                yield return new TestCaseData(7, 3, 6 / 8f / 3, -7);
                yield return new TestCaseData(8, 4, 7 / 8f / 4, -4);
                yield return new TestCaseData(9, 5, 8 / 8f / 5, 0);
            }
        }
    }
}