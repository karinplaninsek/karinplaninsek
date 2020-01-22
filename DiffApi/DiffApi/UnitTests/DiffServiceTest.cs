using System;
using System.Linq;
using DiffApi.Models;
using DiffApi.Services;
using Xunit;

namespace DiffApi.UnitTests
{
    public class DiffServiceTest
    {
        private DiffService service;

        public DiffServiceTest()
        {
            // Arrange
            service = new DiffService();
        }

        // Act
        [Theory]
        [InlineData(null,new byte[0])]
        [InlineData(new byte[0], null)]
        public void GetDiff_NullValue_ThrowArgumentNullException(byte[] left, byte[] right)
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => service.GetDiff(left, right));
        }

        [Fact]
        public void GetDiff_Equals_ReturnEquals()
        {
            var actual = service.GetDiff(new byte[0], new byte[0]);
            Assert.Equal(DiffResultType.Equals, actual.DiffResultType);
            Assert.Null(actual.Diffs);
        }

        [Theory]
        [InlineData(new byte[] { 1,1,1,1,1 }, new byte[0])]
        [InlineData(new byte[0], new byte[] { 1,1,1,1,1 })]
        public void GetDiff_SizeDoNotMatch_ReturnSizeDoNotMatch(byte[] left, byte[] right)
        {
            var actual = service.GetDiff(left, right);
            Assert.Equal(DiffResultType.SizeDoNotMatch, actual.DiffResultType);
            Assert.Null(actual.Diffs);
        }

        [Fact]
        public void GetDiff_BeginsSingle_ReturnContentDoNotMatch()
        {
            var left = new byte[] { 1, 2, 3, 4, 5 };
            var right = new byte[] { 0, 2, 3, 4, 5 };
            var actual = service.GetDiff(left, right);
            Assert.Equal(DiffResultType.ContentDoNotMatch, actual.DiffResultType);
            Assert.NotNull(actual.Diffs);
            Assert.Equal(1, actual.Diffs.Count());
            Assert.Equal(0, actual.Diffs.ElementAt(0).Offset);
            Assert.Equal(1, actual.Diffs.ElementAt(0).Length);
        }

        [Fact]
        public void GetDiff_BeginsMultiple_ReturnContentDoNotMatch()
        {
            var left = new byte[] { 1, 2, 3, 4, 5 };
            var right = new byte[] { 0, 0, 0, 4, 5 };
            var actual = service.GetDiff(left, right);
            Assert.Equal(DiffResultType.ContentDoNotMatch, actual.DiffResultType);
            Assert.NotNull(actual.Diffs);
            Assert.Equal(1, actual.Diffs.Count());
            Assert.Equal(0, actual.Diffs.ElementAt(0).Offset);
            Assert.Equal(3, actual.Diffs.ElementAt(0).Length);
        }

        [Fact]
        public void GetDiff_MiddleSingle_ReturnContentDoNotMatch()
        {
            var left = new byte[] { 1, 2, 3, 4, 5 };
            var right = new byte[] { 1, 2, 0, 4, 5 };
            var actual = service.GetDiff(left, right);
            Assert.Equal(DiffResultType.ContentDoNotMatch, actual.DiffResultType);
            Assert.NotNull(actual.Diffs);
            Assert.Equal(1, actual.Diffs.Count());
            Assert.Equal(2, actual.Diffs.ElementAt(0).Offset);
            Assert.Equal(1, actual.Diffs.ElementAt(0).Length);
        }

        [Fact]
        public void GetDiff_MiddleMultiple_ReturnContentDoNotMatch()
        {
            var left = new byte[] { 1, 2, 3, 4, 5 };
            var right = new byte[] { 1, 0, 0, 0, 5 };
            var actual = service.GetDiff(left, right);
            Assert.Equal(DiffResultType.ContentDoNotMatch, actual.DiffResultType);
            Assert.NotNull(actual.Diffs);
            Assert.Equal(1, actual.Diffs.Count());
            Assert.Equal(1, actual.Diffs.ElementAt(0).Offset);
            Assert.Equal(3, actual.Diffs.ElementAt(0).Length);
        }

        [Fact]
        public void GetDiff_EndSingle_ReturnContentDoNotMatch()
        {
            var left = new byte[] { 1, 2, 3, 4, 5 };
            var right = new byte[] { 1, 2, 3, 4, 0 };
            var actual = service.GetDiff(left, right);
            Assert.Equal(DiffResultType.ContentDoNotMatch, actual.DiffResultType);
            Assert.NotNull(actual.Diffs);
            Assert.Equal(1, actual.Diffs.Count());
            Assert.Equal(4, actual.Diffs.ElementAt(0).Offset);
            Assert.Equal(1, actual.Diffs.ElementAt(0).Length);
        }

        [Fact]
        public void GetDiff_EndMultiple_ReturnContentDoNotMatch()
        {
            var left = new byte[] { 1, 2, 3, 4, 5 };
            var right = new byte[] { 1, 2, 0, 0, 0 };
            var actual = service.GetDiff(left, right);
            Assert.Equal(DiffResultType.ContentDoNotMatch, actual.DiffResultType);
            Assert.NotNull(actual.Diffs);
            Assert.Equal(1, actual.Diffs.Count());
            Assert.Equal(2, actual.Diffs.ElementAt(0).Offset);
            Assert.Equal(3, actual.Diffs.ElementAt(0).Length);
        }

        [Fact]
        public void GetDiff_Many_ReturnContentDoNotMatch()
        {
            var left = new byte[] { 1, 2, 3, 4, 5 };
            var right = new byte[] { 0, 0, 3, 4, 0 };
            var actual = service.GetDiff(left, right);
            Assert.Equal(DiffResultType.ContentDoNotMatch, actual.DiffResultType);
            Assert.NotNull(actual.Diffs);
            Assert.Equal(2, actual.Diffs.Count());
            Assert.Equal(0, actual.Diffs.ElementAt(0).Offset);
            Assert.Equal(2, actual.Diffs.ElementAt(0).Length);
            Assert.Equal(4, actual.Diffs.ElementAt(1).Offset);
            Assert.Equal(1, actual.Diffs.ElementAt(1).Length);
        }

        [Fact]
        public void GetDiff_Whole_ReturnContentDoNotMatch()
        {
            var left = new byte[] { 1, 2, 3, 4, 5 };
            var right = new byte[] { 0, 0, 0, 0, 0 };
            var actual = service.GetDiff(left, right);
            Assert.Equal(DiffResultType.ContentDoNotMatch, actual.DiffResultType);
            Assert.NotNull(actual.Diffs);
            Assert.Equal(1, actual.Diffs.Count());
            Assert.Equal(0, actual.Diffs.ElementAt(0).Offset);
            Assert.Equal(5, actual.Diffs.ElementAt(0).Length);
        }
    }
}
