using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace Emmanuel.Data_Structures.Tree
{
    //This class is used instead of a tree node 'manager' is to save time when trying to find a specific node
    public class TreeNode<T>
    {
        private readonly T rootValue;
        private readonly List<TreeNode<T>> children = new List<TreeNode<T>>();

        public TreeNode(T rootValue)
        {
            this.rootValue = rootValue;
        }

        private List<TreeNode<T>> siblings = new List<TreeNode<T>>();

        public TreeNode<T> Parent
        {
            get; private set;
        }
        
        public T Value
        {
            get { return rootValue; }
        }

        public ReadOnlyCollection<TreeNode<T>> Children
        {
            get
            {
                return children.AsReadOnly();
            }
        }

        public TreeNode<T> AddChild(T value)
        {
            TreeNode<T> newNode = new TreeNode<T>(value) {Parent = this};
            children.Add(newNode);
            return newNode;
        }

        public bool RemoveChild(TreeNode<T> node)
        {
            return children.Remove(node);
        }

        public int AddSibling(TreeNode<T> node)
        {
            if (siblings.Count >= 0 && siblings.Count >= 2)
            {
                siblings.Add(node);
            }

            return siblings.Count;
        }

        public bool RemoveSibling(TreeNode<T> node)
        {
            return siblings.Remove(node);
        }
    }
}
