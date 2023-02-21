using System;
using System.Collections.Generic;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_ArgIsNull_ThrowArgNullException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }


        [Test]
        public void Push_ValidArg_AddTheObjectToTheStack()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            Assert.That(stack.Count, Is.EqualTo(1));
        }



        [Test]
        public void Push_FirstMember_CountIs1()
        {
            var stack = new TestNinja.Fundamentals.Stack<int>();
            Assert.AreEqual(stack.Count, 0);
            stack.Push(1);
            Assert.AreEqual(stack.Count, 1);
        }

        [Test]
        public void Push2Members_Pop1Member_GetCorrectMember()
        {
            var stack = new TestNinja.Fundamentals.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(stack.Count, 2);

            var rlt = stack.Pop();
            Assert.AreEqual(rlt, 2);
            Assert.AreEqual(stack.Count, 1);

            var rlt2 = stack.Pop();
            Assert.AreEqual(rlt2, 1);
            Assert.AreEqual(stack.Count, 0);
        }

        [Test]
        public void StackIsEmpty_Pop_ThrowException()
        {
            var stack = new Fundamentals.Stack<int>();
            Assert.Throws<InvalidOperationException>(() => { stack.Pop(); });
        }

        [Test]
        public void Push2Members_Peek_GetCorrectMember()
        {
            var stack = new TestNinja.Fundamentals.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            var rlt = stack.Peek();
            Assert.AreEqual(rlt, 2);
            Assert.AreEqual(stack.Count, 2);
        }

        [Test]
        public void StackIsEmpty_Peek_GetException()
        {
            var stack = new TestNinja.Fundamentals.Stack<int>();
            Assert.Throws<InvalidOperationException>(() => { stack.Peek(); });
            Assert.Catch<Exception>(() => { stack.Peek(); });
        }
    }
}