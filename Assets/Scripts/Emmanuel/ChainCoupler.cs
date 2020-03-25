namespace Emmanuel
{
    /// <summary>
    /// this class is meant to link the beginning of chain, and to another coupler
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ChainCoupler<T>
    {
        /// <summary>
        /// the origin node, beginning of the whole chain system
        /// </summary>
        private ChainNode<T> originNode;
    
        /// <summary>
        /// beginning of the linked chain
        /// </summary>
        private ChainNode<T> beginningOfChain;

        /// <summary>
        /// end of the linked chain
        /// </summary>
        public ChainNode<T> endOfChain;

    
        /// <summary>
        /// conctructor
        /// </summary>
        /// <param name="origin"></param>
        public ChainCoupler(ChainNode<T> origin)
        {
            originNode = origin;
        }

        /// <summary>
        /// begins a new chain linked to the coupler
        /// NOTE:: Should never be used more than once, will cause any data held in the chain to be lost
        /// </summary>
        /// <param name="chainData"></param>
        public void LinkNewChain(T chainData)
        {
            beginningOfChain = new ChainNode<T>(chainData);
        }

        /// <summary>
        /// adds a chain node to the end, then it updates the end of the chain
        /// </summary>
        /// <param name="newNodeData"></param>
        public void AddChainNode(T newNodeData)
        {
            ChainNode<T> newEndNode = new ChainNode<T>(newNodeData);
            endOfChain.childNode = newEndNode;
            endOfChain = endOfChain.childNode;
        }

    }
}
