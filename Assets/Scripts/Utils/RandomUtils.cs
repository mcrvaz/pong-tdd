public class RandomUtils {

    public IRandom randomProxy;

    public RandomUtils() {
        this.randomProxy = new RandomProxy();
    }

    /// <summary>
    ///     Returns the value or its opposite.
    /// </summary>
    /// <param name="value">Value to be randomized.</param>
    /// <returns>The value or its opposite.</returns>
    public int Opposite(int value) {
        var oneOrMinusOne = (randomProxy.Range(0, 2) * 2) - 1;
        return oneOrMinusOne * value;
    }

}
