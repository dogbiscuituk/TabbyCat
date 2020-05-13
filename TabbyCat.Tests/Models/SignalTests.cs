namespace TabbyCat.Tests.Models
{
    using NUnit.Framework;
    using TabbyCat.Models;
    using Types;

    [TestFixture]
    public class SignalTests
    {
        // Private fields

        private readonly Signal _signal = new Signal();

        // Public methods

        [Test]
        public void TestSignalName() => Assert.AreEqual(string.Empty, _signal.Name);

        [Test]
        public void TestSignalWaveType() => Assert.AreEqual(WaveType.Constant, _signal.WaveType);

        [Test]
        public void TestSignalAmplitude() => Assert.AreEqual(0, _signal.Amplitude);

        [Test]
        public void TestSignalAmplitudeMaximum() => Assert.AreEqual(1, _signal.AmplitudeMaximum);

        [Test]
        public void TestSignalAmplitudeMinimum() => Assert.AreEqual(0, _signal.AmplitudeMinimum);

        [Test]
        public void TestSignalFrequency() => Assert.AreEqual(1, _signal.Frequency);

        [Test]
        public void TestSignalFrequencyMaximum() => Assert.AreEqual(10, _signal.FrequencyMaximum);

        [Test]
        public void TestSignalFrequencyMinimum() => Assert.AreEqual(0.1f, _signal.FrequencyMinimum);

        [TestCaseSource(typeof(SignalTestsData), nameof(SignalTestsData.ConstantTestCases))]
        public void TestGetValueConstant(float amplitude, float frequency, float time, float expected) => TestGetValue(WaveType.Constant, amplitude, frequency, time, expected);

        [TestCaseSource(typeof(SignalTestsData), nameof(SignalTestsData.RampDownTestCases))]
        public void TestGetValueRampDown(float amplitude, float frequency, float time, float expected) => TestGetValue(WaveType.RampDown, amplitude, frequency, time, expected);

        [TestCaseSource(typeof(SignalTestsData), nameof(SignalTestsData.RampUpTestCases))]
        public void TestGetValueRampUp(float amplitude, float frequency, float time, float expected) => TestGetValue(WaveType.RampUp, amplitude, frequency, time, expected);

        [TestCaseSource(typeof(SignalTestsData), nameof(SignalTestsData.SineTestCases))]
        public void TestGetValueSine(float amplitude, float frequency, float time, float expected) => TestGetValue(WaveType.Sine, amplitude, frequency, time, expected);

        [TestCaseSource(typeof(SignalTestsData), nameof(SignalTestsData.SquareTestCases))]
        public void TestGetValueSquare(float amplitude, float frequency, float time, float expected) => TestGetValue(WaveType.Square, amplitude, frequency, time, expected);

        [TestCaseSource(typeof(SignalTestsData), nameof(SignalTestsData.TriangleTestCases))]
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
