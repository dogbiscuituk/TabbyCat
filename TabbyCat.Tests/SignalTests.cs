namespace TabbyCat.Tests
{
    using Common.Types;
    using Models;
    using NUnit.Framework;

    [TestFixture]
    public class SignalTests
    {
        // Public methods

        [TestCaseSource(typeof(SingalTestData), "ConstantTestCases")]
        public void TestGetValueConstant(float amplitude, float frequency, float time, float expected) => TestGetValue(WaveType.Constant, amplitude, frequency, time, expected);

        [TestCaseSource(typeof(SingalTestData), "ReverseSawtoothTestCases")]
        public void TestGetValueReverseSawtooth(float amplitude, float frequency, float time, float expected) => TestGetValue(WaveType.RampDown, amplitude, frequency, time, expected);

        [TestCaseSource(typeof(SingalTestData), "SawtoothTestCases")]
        public void TestGetValueSawtooth(float amplitude, float frequency, float time, float expected) => TestGetValue(WaveType.RampUp, amplitude, frequency, time, expected);

        [TestCaseSource(typeof(SingalTestData), "SineTestCases")]
        public void TestGetValueSine(float amplitude, float frequency, float time, float expected) => TestGetValue(WaveType.Sine, amplitude, frequency, time, expected);

        [TestCaseSource(typeof(SingalTestData), "SquareTestCases")]
        public void TestGetValueSquare(float amplitude, float frequency, float time, float expected) => TestGetValue(WaveType.Square, amplitude, frequency, time, expected);

        [TestCaseSource(typeof(SingalTestData), "TriangleTestCases")]
        public void TestGetValueTriangle(float amplitude, float frequency, float time, float expected) => TestGetValue(WaveType.Triangle, amplitude, frequency, time, expected);

        // Private static methods

        private static void TestGetValue(WaveType waveType, float amplitude, float frequency, float time, float expected)
        {
            var signal = new Signal { WaveType = waveType, Amplitude = amplitude, Frequency = frequency };
            const float e = 2e-6f;
            var range = expected < 0
                ? (expected * (1 + e), expected * (1 - e))
                : (expected * (1 - e), expected * (1 + e));
            Assert.That(signal.GetValueAt(time), Is.InRange(range.Item1 - e, range.Item2 + e));
        }
    }
}
