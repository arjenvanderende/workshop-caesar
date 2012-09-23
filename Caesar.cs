using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyroxene.Kata.Caesar
{
	public class Caesar
	{
		private const int CharactersInAlphabet = 26;
		private const char FirstCharInAlphabet = 'A';
		private const char LastCharInAlphabet = 'Z';

		public string Encode(string text, int offset) {
			EnsureValidInput(text);
			StringBuilder result = new StringBuilder();
			foreach (char c in UpperCasedCharacters(text)) {
				result.Append(CaesarCharacter(c, offset));
			}
			return result.ToString();
		}

		private void EnsureValidInput(string text) {
			if (UpperCasedCharacters(text).Any(c => c < FirstCharInAlphabet || c > LastCharInAlphabet)) {
				throw new ArgumentException("text is invalid");
			}
		}

		private IEnumerable<char> UpperCasedCharacters(string text) {
			return text.ToUpperInvariant().ToCharArray();
		}

		private int Normalize(int offset) {
			return offset % CharactersInAlphabet;
		}

		private char CaesarCharacter(char c, int offset) {
			return WrapCharacter(OffsetCharacter(c, offset));
		}

		private char OffsetCharacter(char c, int offset) {
			return (char)(c + Normalize(offset));
		}

		private char WrapCharacter(char character) {
			if (character > LastCharInAlphabet) {
				return (char)(character - CharactersInAlphabet);
			}
			if (character < FirstCharInAlphabet) {
				return (char)(character + CharactersInAlphabet);
			}
			return character;
		}
	}
}