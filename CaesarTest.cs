using System;
using NUnit.Framework;

namespace Pyroxene.Kata.Caesar
{
	[TestFixture]
	public class CaesarTest
	{
		[Test]
		public void ReturnsStringWithRot0() {
			Caesar caesar = makeCeasar();
			Assert.AreEqual("A", caesar.Encode("A", 0));
		}

		[Test]
		public void ReturnsUpperCaseInput() {
			Caesar caesar = makeCeasar();
			Assert.AreEqual("A", caesar.Encode("a", 0));
		}

		[Test]
		public void ReturnsInputWithOffsetOfOne() {
			Caesar caesar = makeCeasar();
			Assert.AreEqual("B", caesar.Encode("A", 1));
		}

		[Test]
		public void ReturnsInputWithTwoCharactersWithOffsetOfOne() {
			Caesar caesar = makeCeasar();
			Assert.AreEqual("BC", caesar.Encode("AB", 1));
		}

		[Test]
		public void ReturnsWrappedCharacterGivenOffsetForInputExceedsCharacterSet() {
			Caesar caesar = makeCeasar();
			Assert.AreEqual("A", caesar.Encode("Z", 1));
		}

		[Test]
		public void ReturnsWrappedCharacterGivenNegativeOffsetForInputExceedsCharacterSet() {
			Caesar caesar = makeCeasar();
			Assert.AreEqual("Z", caesar.Encode("A", -1));
		}

		[Test]
		public void ReturnsWrappedCharacterGivenCharacterWrapsMultipleTimes() {
			Caesar caesar = makeCeasar();
			Assert.AreEqual("B", caesar.Encode("A", 53));
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void ThrowsGivenInputIsContainsInvalidCharacters() {
			const string invalidCharacter = "!";
			Caesar caesar = makeCeasar();
			caesar.Encode(invalidCharacter, 53);
		}

		// WRONG INPUT

		private Caesar makeCeasar() {
			return new Caesar();
		}
	}
}