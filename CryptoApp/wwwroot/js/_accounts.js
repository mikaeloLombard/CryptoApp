

async function main() {
    var walletBalance = function (options) {



        const { ethers } = require("ethers");

        const INFURA_ID = '2a940692883f4772964858700a40b3f7'
        const provider = new ethers.providers.JsonRpcProvider(`https://mainnet.infura.io/v3/2a940692883f4772964858700a40b3f7 `)

        const address = '0xB24D332Cd32163Ff938F3eB3455c5F6A44069B2d'
        const main = async () => {
            const balance = await provider.getBalance(address)
            const print = `\nETH Balance of ${address} --> ${ethers.utils.formatEther(balance)} ETH\n`
            console.log(`\nETH Balance of ${address} --> ${ethers.utils.formatEther(balance)} ETH\n`)


        }
        ViewData["UpBalance"] = print;

    }
    main()
}