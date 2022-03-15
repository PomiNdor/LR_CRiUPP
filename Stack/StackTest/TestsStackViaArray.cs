using NUnit.Framework;
using CRiUPP_lab_01;

namespace StackTests
{
  public class TestsStackViaArray
  {
    [Test]
    public void TestPeekEmptyStack()
    {
      IStack<int> stack = new StackViaArray<int>();

      Assert.Throws<System.NullReferenceException>(() => { 
        stack.Peek();
      });
    }

    [Test]
    public void TestPopEmptyStack()
    {
      IStack<int> stack = new StackViaArray<int>();

      Assert.Throws<System.InvalidOperationException>(() => {
        stack.Pop();
      });
    }

    [TestCase(1, 1)]
    [TestCase(4, 7, 4)]
    [TestCase(-23, 1, 2, 3, 4, -23)]
    public void TestPeek(int expected, params int[] collection)
    {
      IStack<int> stack = new StackViaArray<int>(collection);
      int actual = stack.Peek();
      Assert.AreEqual(expected, actual);
    }

    [TestCase(1, 1)]
    [TestCase(4, 7, 4)]
    [TestCase(-23, 1, 2, 3, 4, -23)]
    public void TestPop(int expected, params int[] collection)
    {
      IStack<int> stack = new StackViaArray<int>(collection);
      int actual = stack.Pop();
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TestPeekNoRemove()
    {
      int expected = 3;
      IStack<int> stack = new StackViaArray<int>(new int[] { 1, 2, 3 });

      stack.Peek();
      int actual = stack.Peek();
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TestPopRemove()
    {
      int expected = 2;
      IStack<int> stack = new StackViaArray<int>(new int[] { 1, 2, 3 });
      
      stack.Pop();
      int actual = stack.Pop();
      Assert.AreEqual(expected, actual);
    }


    [Test]
    public void TestClear()
    {
      IStack<int> stack = new StackViaArray<int>(new int[] { 1, 2, 3 });
      stack.Clear();
      Assert.AreEqual(0, stack.Count);
    }

    [TestCase(false, 7)]
    [TestCase(true, 2, 1, 2, 3)]
    [TestCase(false, 7, 1, 2, 3)]
    public void TestContains(bool expected, int item, params int[] collection)
    {
      IStack<int> stack = new StackViaArray<int>(collection);
      bool actual = stack.Contains(item);
      Assert.AreEqual(expected, actual);
    }

    [TestCase(new int[] { 1, 2, 3 }, 1, 2, 3)]
    [TestCase(new int[] { 1 }, 1)]
    [TestCase(new int[] { })]
    public void TestEnumerable(int[] expected, params int[] collection)
    {
      var stack = new StackViaArray<int>(collection);
      int i = 0;

      foreach (var element in stack)
        Assert.AreEqual(expected[i++], element);
    }

    [Test]
    public void TestCloneable()
    {
      var stack = new StackViaArray<int>(new int[] { 1, 2, 3 });
      var stack_clone = (StackViaArray<int>)stack.Clone();

      Assert.AreEqual(stack, stack_clone);
      stack.Pop();
      Assert.AreNotEqual(stack, stack_clone);
    }
  }
}