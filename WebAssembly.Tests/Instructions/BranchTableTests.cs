﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAssembly.Instructions
{
	/// <summary>
	/// Tests the <see cref="BranchTable"/> instruction.
	/// </summary>
	[TestClass]
	public class BranchTableTests
	{
		/// <summary>
		/// Tests compilation and execution of the <see cref="BranchTable"/> instruction.
		/// </summary>
		[TestMethod]
		public void BranchTable_Compiled()
		{
			var exports = AssemblyBuilder.CreateInstance<CompilerTestBase>("Test",
				ValueType.Int32,
				 new[]
				 {
					 ValueType.Int32
				 },
				new Block(BlockType.Empty),
				new Block(BlockType.Empty),
				new Block(BlockType.Empty),
				new Block(BlockType.Empty),
				new GetLocal(0),
				new BranchTable(0, 0, 1, 2, 3),
				new End(),
				new Int32Constant(1),
				new Return(),
				new End(),
				new Int32Constant(2),
				new Return(),
				new End(),
				new Int32Constant(3),
				new Return(),
				new End(),
				new Int32Constant(4),
				new Return(),
				new End());

			Assert.AreEqual(1, exports.Test(-1));
			Assert.AreEqual(1, exports.Test(0));
			Assert.AreEqual(2, exports.Test(1));
			Assert.AreEqual(3, exports.Test(2));
			Assert.AreEqual(4, exports.Test(3));
			Assert.AreEqual(1, exports.Test(4));
			Assert.AreEqual(1, exports.Test(5));
		}
	}
}