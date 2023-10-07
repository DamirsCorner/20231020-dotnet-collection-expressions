using FluentAssertions;

namespace CollectionExpressions;

public class CollectionExpressionTests
{
    [Test]
    public void InitializesArray()
    {
        var oldSyntax = new[] { 1, 2, 3 };
        int[] newSyntax = [1, 2, 3];

        newSyntax.Should().BeEquivalentTo(oldSyntax);
    }

    [Test]
    public void InitializesJaggedArray()
    {
        var oldSyntax = new[]
        {
            new[] { 1, 2 },
            new[] { 3, 4 },
            new[] { 5, 6 },
        };

        int[][] newSyntax = [[1, 2], [3, 4], [5, 6]];

        newSyntax.Should().BeEquivalentTo(oldSyntax);
    }

    [Test]
    public void InitializesSpan()
    {
        // Cannot initialize type 'Span<int>' with a collection initializer because it does not implement 'System.Collections.IEnumerable'
        //var oldSyntax = new Span<int> { 1, 2, 3 };
        Span<int> newSyntax = [1, 2, 3];

        newSyntax.ToArray().Should().ContainInOrder(1, 2, 3);
    }

    [Test]
    public void SupportsSpreadElement()
    {
        int[] array = [1, 2];
        Span<int> span = [3, 4];
        List<int> list = [5, 6];
        int[] finalArray = [.. array, .. span, .. list];

        finalArray.Should().ContainInOrder(1, 2, 3, 4, 5, 6);
    }
}