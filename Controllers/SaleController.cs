using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class SaleController : Controller
    {
        private readonly ShopDBContext dBContext;
        public SaleController(ShopDBContext dBContext)
        {
            this.dBContext = dBContext;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateSale(SaleModel saleModel)
        {
            if (ModelState.IsValid)
            {
                if(saleModel.AdvancePayment > saleModel.TotalAmount)
                {
                    return RedirectToAction("Index",  "Error");
                }

                string getDate = DateTime.Now.ToString("yyyy/MM/dd");

                Tblcustomer checkCustomer = dBContext.Tblcustomers.Where(x => x.CustomerCnic == saleModel.CNIC).FirstOrDefault();

                 string customerID = null;
                if(checkCustomer == null)
                {
                    customerID = Guid.NewGuid().ToString();
                    Tblcustomer customer = new Tblcustomer();
                    customer.CustomerId = customerID;
                    customer.CustomerName = saleModel.CustomerName;
                    customer.CustomerFathername = saleModel.FatherName;
                    customer.CustomerCnic = saleModel.CNIC;
                    customer.CustomerMobileno = saleModel.MobileNumber;
                    customer.CustomerAddress = saleModel.CustomerAddress;
                    customer.CustomerReference = saleModel.CustomerRefference;
                    customer.CustomerCreationdate = DateTime.Now;
                    dBContext.Add(customer);
                    // dBContext.SaveChanges();
                }else{
                    customerID = checkCustomer.CustomerId;
                }

                

                string productID = Guid.NewGuid().ToString();
                Tblproduct product = new Tblproduct();
                product.ProductId = productID;
                product.ProductName = saleModel.ProductName;
                product.ProductDesc = saleModel.ProductDescription;
                product.ProductCreationdate = DateTime.Now;


                string saleID = Guid.NewGuid().ToString();
                Tblsale sale = new Tblsale();
                sale.SaleId = saleID;
                sale.CustomerId = customerID;
                sale.Imei1 = saleModel.Imei1;
                sale.Imei2 = saleModel.Imei2;
                sale.ProductId = productID;
                sale.SaleTotalamount = saleModel.TotalAmount;
                sale.SalePaidAmount = saleModel.AdvancePayment;
                sale.SaleRemainingamount = saleModel.TotalAmount - saleModel.AdvancePayment;
                sale.Status = "Active";
                sale.SaleMonthlyinstallements = saleModel.MonthlyInstallment;
                sale.SaleDate = DateTime.Now;
                

                string PaymentID = Guid.NewGuid().ToString();
                Tblpayment payment = new Tblpayment();
                payment.PayId = PaymentID;
                payment.SaleId = saleID;
                payment.PayAmount = saleModel.AdvancePayment;
                payment.Status = "ap";
                payment.PayDate = DateTime.Now;

                
                

                dBContext.Add(product);
                // dBContext.SaveChanges();

                dBContext.Add(sale);
                // dBContext.SaveChanges();

                dBContext.Add(payment);
                dBContext.SaveChanges();

            }
            return RedirectToAction("Index" , "MonthlyInstallment");
        }

        public IActionResult ImportSale()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImportSale(ImportSaleModel saleModel)
        {
            string filename = await UploadFile(saleModel.file);
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(Path.Combine(Directory.GetCurrentDirectory(), "Upload" + "/"+filename)))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = false;
                    //read column names
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                    DataColumn datecolumn = new DataColumn(column);
                    datecolumn.AllowDBNull = true;
                    csvData.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                    string[] fieldData = csvReader.ReadFields();
                    //Making empty value as null
                    for (int i = 0; i < fieldData.Length; i++)
                    {
                        if (fieldData[i] == "")
                        {
                            fieldData[i] = null;
                        }
                    }
                    csvData.Rows.Add(fieldData);
                    } 
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            for (int i = 0; i < csvData.Rows.Count; i++)
            {
                Tblcustomer checkCustomer = dBContext.Tblcustomers
                .Where(x => x.CustomerCnic == csvData.Rows[i][2].ToString())
                .FirstOrDefault();

                string customerID = null;
                if(checkCustomer == null)
                {
                    customerID = Guid.NewGuid().ToString();
                    Tblcustomer customer = new Tblcustomer();
                    customer.CustomerId = customerID;
                    customer.CustomerName = csvData.Rows[i][0].ToString();
                    customer.CustomerFathername = csvData.Rows[i][1].ToString();
                    customer.CustomerCnic = csvData.Rows[i][2].ToString();
                    customer.CustomerMobileno = csvData.Rows[i][3].ToString();
                    customer.CustomerAddress = csvData.Rows[i][4].ToString();
                    customer.CustomerReference = csvData.Rows[i][5].ToString();
                    customer.CustomerCreationdate = DateTime.Now;
                    dBContext.Add(customer);
                    // dBContext.SaveChanges();
                }else{
                    customerID = checkCustomer.CustomerId;
                }

                string productID = Guid.NewGuid().ToString();
                Tblproduct product = new Tblproduct();
                product.ProductId = productID;
                product.ProductName = csvData.Rows[i][6].ToString();
                product.ProductDesc = csvData.Rows[i][9].ToString();
                product.ProductCreationdate = DateTime.Now;


                string saleID = Guid.NewGuid().ToString();
                Tblsale sale = new Tblsale();
                sale.SaleId = saleID;
                sale.CustomerId = customerID;
                sale.Imei1 = csvData.Rows[i][7].ToString();
                sale.Imei2 = csvData.Rows[i][8].ToString();
                sale.ProductId = productID;
                sale.SaleTotalamount = Convert.ToDecimal(csvData.Rows[i][10]);
                sale.SalePaidAmount = Convert.ToDecimal(csvData.Rows[i][12]);
                sale.SaleRemainingamount = sale.SaleTotalamount - sale.SalePaidAmount;
                sale.Status = "Active";
                sale.SaleMonthlyinstallements = Convert.ToDecimal(csvData.Rows[i][11]);
                sale.SaleDate = DateTime.Now;
                

                string PaymentID = Guid.NewGuid().ToString();
                Tblpayment payment = new Tblpayment();
                payment.PayId = PaymentID;
                payment.SaleId = saleID;
                payment.PayAmount = Convert.ToDecimal(csvData.Rows[i][12]);
                payment.Status = "ap";
                payment.PayDate = DateTime.Now;

                
                

                dBContext.Add(product);
                // dBContext.SaveChanges();

                dBContext.Add(sale);
                // dBContext.SaveChanges();

                dBContext.Add(payment);
            }
            

                

                
            dBContext.SaveChanges();



            TempData["msg"] = "File Imported Successfully!!!";
            return View();
        }

        // Upload file on server
        public async Task<string> UploadFile(IFormFile file)
        {
            string path = "";
            string filename = "";
            try {
                if (file.Length > 0)
                {
                    filename = Guid.NewGuid()+Path.GetExtension(file.FileName);
                    if(!Directory.Exists("Upload"))
                    {
                        Directory.CreateDirectory("Upload");
                    }
                    path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "Upload"));
                    using (var filestream = new FileStream(Path.Combine(path,filename), FileMode.Create))
                    {
                        await file.CopyToAsync(filestream);
                    }
                }
                else{
                    path = "";
                }
            }catch(Exception e)
            {
                Console.Write(e.Message);
            }
            return filename;
        }
    }
}