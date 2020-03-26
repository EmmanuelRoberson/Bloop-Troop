namespace Emmanuel
{
    /// <summary>
    /// this class is meant to link the beginning of chain, and to another coupler
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ChainCoupler<T>
    {
        /// <summary>
        /// maximum length of the chain
        /// </summary>
        private int maxChainLength;

        /// <summary>
        /// keeps track of number of nodes in the chain
        /// </summary>
        private int currentChainLength;
        
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
        /// constructor
        /// </summary>
        /// <param name="chainLength"></param>
        /// <param name="originNodeData"></param>
        /// <param name="beginningChainData"></param>
        public ChainCoupler(int chainLength , ChainNode<T> existingOriginNode, T beginningChainData)
        {
            originNode = existingOriginNode;
            maxChainLength = chainLength;
            currentChainLength = 0;
            LinkNewChain(beginningChainData);
        }

        /// <summary>
        /// begins a new chain linked to the coupler
        /// NOTE:: Should never be used more than once, will cause any data held in the chain to be lost
        /// </summary>
        /// <param name="chainData"></param>
        public void LinkNewChain(T chainData)
        {
            if (currentChainLength <= maxChainLength)
            {
                beginningOfChain = new ChainNode<T>(chainData);
                currentChainLength++;
            }
        }

        /// <summary>
        /// adds a chain node to the end, then it updates the end of the chain
        /// </summary>
        /// <param name="newNodeData"></param>
        public void AddNode(T newNodeData)
        {
            ChainNode<T> newEndNode = new ChainNode<T>(newNodeData);
            endOfChain.childNode = newEndNode;
            endOfChain = endOfChain.childNode;
        }
        
        /// <summary>
        /// removes a node from the end of the chain
        /// </summary>
        public void RemoveNode()
        {
            endOfChain = endOfChain.parentNode;
            endOfChain.childNode = null;
        }

        public ChainNode<T> EndOfChain
        {
            get => endOfChain;
        }
    }
}
