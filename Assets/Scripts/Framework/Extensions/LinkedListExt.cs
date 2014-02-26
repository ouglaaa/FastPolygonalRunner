using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastPolygonalRunner.Framework.Extensions
{
	public static class LinkedListExt
	{
		public static LinkedListNode<T> GetPreviousCircular<T>(this LinkedListNode<T> node) 
		{
			if (node.Previous == null)
				return node.List.Last;
			return node.Previous;
		}
		public static LinkedListNode<T> GetNextCircular<T>(this LinkedListNode<T> node)
		{
			if (node.Next== null)
				return node.List.First;
			return node.Next;
		}

		public static LinkedListNode<T> GetPreviousNotNull<T>(this LinkedListNode<T> node) 
		{
			if (node.Previous == null)
				return node;
			return node.Previous;
		}
		public static LinkedListNode<T> GetNextNotNull<T>(this LinkedListNode<T> node)
		{
			if (node.Next== null)
				return node;
			return node.Next;
		}

	}
}
