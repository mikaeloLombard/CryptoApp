

async function mainA() {
    import { ethers } from "ethers";
    /*const provider = new AlchemyProvider();*/
    const provider = new AlchemyProvider([network = "homestead", [YpqYeAGDm9qp0c05N8OfbGGrlD5S6zcs]]);
    /*const web3 = createAlchemyWeb3("https://eth-mainnet.alchemyapi.io/v2/YpqYeAGDm9qp0c05N8OfbGGrlD5S6zcs");*/
    const blockNumber = await provider.getTransactionCount(0xC1da66a4aA9DFcf60B891105AF58F4AD4AFfaA9f,blockTag = latest);
    var blockNumber1 = ("The latest block number is " + blockNumber);
    /*console.log("The latest block number is " + blockNumber);*/
    $("#Test").text(blockNumber1);
    
}
mainA();