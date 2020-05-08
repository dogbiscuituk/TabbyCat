namespace TabbyCat.Tests.Models
{
    using NUnit.Framework;
    using TabbyCat.Models;
    using TabbyCat.Types;

    [TestFixture]
    public class SignalTests
    {
        private Signal Signal = new Signal();

        // Public methods

        [Test]
        public void TestSignalName() => Assert.AreEqual(string.Empty, Signal.Name);

        [Test]
        public void TestSignalWaveType() => Assert.AreEqual(WaveType.Constant, Signal.WaveType);

        [Test]
        public void TestSignalAmplitude() => Assert.AreEqual(0, Signal.Amplitude);

        [Test]
        public void TestSignalAmplitudeMaximum() => Assert.AreEqual(1, Signal.AmplitudeMaximum);

        [Test]
        public void TestSignalAmplitudeMinimum() => Assert.AreEqual(0, Signal.AmplitudeMinimum);

        [Test]
        public void TestSignalFrequency() => Assert.AreEqual(1, Signal.Frequency);

        [Test]
        public void TestSignalFrequencyMaximum() => Assert.AreEqual(10, Signal.FrequencyMaximum);

        [Test]
        public void TestSignalFrequencyMinimum() => Assert.AreEqual(0.1f, Signal.FrequencyMinimum);

        [TestCaseSource(typeof(SingalTestsData), "ConstantTestCases")]
        public void TestGetValueConstant(float amplitude, float frequency, float time, float expected) => TestGetValue(WaveType.Constant, amplitude, frequency, time, expected);

        [TestCaseSource(typeof(SingalTestsData), "RampDownTestCases")]
        public void TestGetValueRampDown(float amplitude, float frequency, float time, float expected) => TestGetValue(WaveType.RampDown, amplitude, frequency, time, expected);

        [TestCaseSource(typeof(SingalTestsData), "RampUpTestCases")]
        public void TestGetValueRampUp(float amplitude, float frequency, float time, float expected) => TestGetValue(WaveType.RampUp, amplitude, frequency, time, expected);

        [TestCaseSource(typeof(SingalTestsData), "SineTestCases")]
        public void TestGetValueSine(float amplitude, float frequency, float time, float expected) => TestGetValue(WaveType.Sine, amplitude, frequency, time, expected);

        [TestCaseSource(typeof(SingalTestsData), "SquareTestCases")]
        public void TestGetValueSquare(float amplitude, float frequency, float time, float expected) => TestGetValue(WaveType.Square, amplitude, frequency, time, expected);

        [TestCaseSource(typeof(SingalTestsData), "TriangleTestCases")]
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
