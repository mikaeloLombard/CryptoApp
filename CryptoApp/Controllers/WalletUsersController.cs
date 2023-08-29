using CryptoApp.Data;
using CryptoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;

using System.Linq;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Web3.Accounts.Managed;
using Nethereum.Hex.HexTypes;
using Nethereum.Hex.HexConvertors.Extensions;
using System.Diagnostics;

using System.Runtime.InteropServices;
using System.Collections.Generic;
using Nest;

namespace CryptoApp.Controllers
{
    public class WalletUsersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public WalletUsersController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {//add3
            IEnumerable<WalletUsers> objList = _db.WalletUsers;
            return View(objList);
        }


        //GET-Create
        public IActionResult Create()
        {

            return View();
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WalletUsers obj)
        {
            _db.WalletUsers.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET-EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.WalletUsers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST-EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WalletUsers obj)
        {
            if (ModelState.IsValid)
            {
                _db.WalletUsers.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET-Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.WalletUsers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        //POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.WalletUsers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.WalletUsers.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }


        public async Task<IActionResult> Details(int? id)
        {
            
            var obj = _db.WalletUsers.Find(id);
            var selection = obj.PublicAdress;

            if (obj == null)
            {
                return NotFound();

            }
            var web3 = new Web3("https://eth-mainnet.alchemyapi.io/v2/YpqYeAGDm9qp0c05N8OfbGGrlD5S6zcs");

            var balance = await web3.Eth.GetBalance.SendRequestAsync(obj.PublicAdress);
            ViewData["countTrans"] = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync(obj.PublicAdress);


            //var transactions = web3.Eth.getTransactionCount.SendRequestAsync(obj.PublicAdress);
            //var transactions = web3.Eth.getBlockTransactionCount.SenRequestAsync(obj.PublicAdress);
            ViewData["MainBalance"] = Web3.Convert.FromWei(balance.Value);
            ViewData["MainBalanceWei"] = balance.Value;
            ViewData["Padress"] = "https://etherscan.io/address/" + selection ;






            return View(obj);
            
            


        }
        

        //public System.Diagnostics.Process CreateWalletChrome(string url)
        //{


        //    ProcessStartInfo processInfo = new ProcessStartInfo
        //    {

        //        FileName = (string)("https://chrome.google.com/webstore/detail/metamask/nkbihfbeogaeaoehlefnkodbefgpgknn"),
        //        UseShellExecute = true

        //    };

        //    return Process.Start(processInfo);

        //}

        //public IActionResult CreateWalletEdge(string url)
        //{
        //    ProcessStartInfo processInfo = new ProcessStartInfo
        //    {

        //        FileName = (string)("https://microsoftedge.microsoft.com/addons/detail/metamask/ejbalbakoplchlghecdalmeeeajnimhm?hl=en-US"),

        //        UseShellExecute = true
        //    };
        //    return (IActionResult)Process.Start(processInfo);

        //}

    }
}


