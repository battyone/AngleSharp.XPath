﻿#region License
// MIT License
//
// Copyright (c) 2018 Denis Ivanov
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using NUnit.Framework;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;

namespace AngleSharp.XPath.Tests
{
	[TestFixture]
	public class HtmlDocumentNavigatorTests
	{
		[Test, Retry(5)]
		public async Task SelectSinleNodeTest()
		{
			// Arrange
			const string address = "https://stackoverflow.com/questions/39471800/is-anglesharps-htmlparser-threadsafe";
			var config = Configuration.Default.WithDefaultLoader();
			var document = await BrowsingContext.New(config).OpenAsync(address);

			// Act
			var content = document.DocumentElement.SelectSingleNode("//div[@id='content']");

			// Assert
			Assert.That(content, Is.Not.Null);
		}

		[Test]
		public void SelectNodes_SelectList_ShouldReturnList()
		{
			// Arrange
			const string html = 
			@"<ol>
				<li>First</li>
				<li>Second</li>
				<li>Third</li>
			</ol>";
			var parser = new HtmlParser();
			var document = parser.Parse(html);

			// Act
			var nodes = document.DocumentElement.SelectNodes("//li");

			// Assert
			Assert.That(nodes, Has.Count.EqualTo(3));
		}
	}
}
