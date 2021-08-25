using E_MarketWF.Properties;
using Guna.UI2.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_MarketWF
{
    public partial class Form1 : Form
    {
        RichTextBox richText = new RichTextBox();
        Product cola = new Product() { Name = "Coca-Cola", Price = 1, StockCount = 120 };
        Product fanta = new Product() { Name = "Fanta", Price = 1, StockCount = 90 };
        Product icetea = new Product() { Name = "Lipton", Price = 1.2, StockCount = 140 };
        Product pepsi = new Product() { Name = "Pepsi", Price = 1, StockCount = 70 };
        Product bread = new Product() { Name = "Bread", Price = 0.5, StockCount = 240 };
        Product snickers = new Product() { Name = "Snickers", Price = 1.7, StockCount = 60 };
        Product twix = new Product() { Name = "Twix", Price = 1.4, StockCount = 65 };
        Product bounty = new Product() { Name = "Bounty", Price = 1.2, StockCount = 48 };
        Product popkek = new Product() { Name = "Pop-Kek", Price = 0.5, StockCount = 54 };
        Product mars = new Product() { Name = "Mars", Price = 1.2, StockCount = 42 };
        Product colgate = new Product() { Name = "Colgate", Price = 2.4, StockCount = 130 };
        Product smoke = new Product() { Name = "Marlboro", Price = 8, StockCount = 75 };
        double odenilmeli_mebleg = 0;
        double all_Price = 0;
        double enter_Price = 0;
        public Form1()
        {
            InitializeComponent();
            richText.Text += "                                        E-MARKET" +
            "\nAddress AZ1142 BAKI SEHERİ XETAI RAYONU" +
            "\nPhone: 994 55 613 63 63" +
            "\n                       ---------------------- Sales ----------------------" +
           $"\nDate: {DateTime.Now.ToShortDateString()}" +
           $"\nKassir: Rasim Ismayilov                               Time: {DateTime.Now.ToLongTimeString()}\n" +
           $"                       **********************************************" +
           $"\nProduct name                                           Quantity\n";
            List<Product> products = new List<Product>() { cola, fanta, icetea, pepsi, bread, snickers, twix, bounty, popkek, mars, colgate, smoke };
            for (int i = 0, j = products.Count - 1; i < products.Count; i++, j--)
            {
                var panel = Controls
                    .OfType<Guna2ShadowPanel>()
                    .ToList()[j].Controls.
                    OfType<Guna2HtmlLabel>();
                panel.ToList()[1].Text = products[i].Price.ToString() + " AZN";
                panel.ToList()[0].Text = products[i].StockCount.ToString();
                Controls.OfType<Guna2NumericUpDown>().ToList()[j].Maximum = products[i].StockCount;
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e) => Application.Exit();
        private void Btn_Minimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
        private void Btn_Close_MouseHover(object sender, EventArgs e) => btn_Close.BackColor = Color.Red;
        private void Btn_Close_MouseLeave(object sender, EventArgs e) => btn_Close.BackColor = Color.Transparent;
        private void Cb_Click(object sender, EventArgs e)
        {
            int index;
            Guna2NumericUpDown nud;
            if (sender is Guna2CustomCheckBox cb)
            {
                if (cb.Checked)
                {
                    index = Controls.OfType<Guna2CustomCheckBox>().ToList().FindIndex(c => c == cb);
                    nud = Controls.OfType<Guna2NumericUpDown>().ToList()[index];
                    nud.Enabled = true;
                }
                else
                {
                    index = Controls.OfType<Guna2CustomCheckBox>().ToList().FindIndex(c => c == cb);
                    nud = Controls.OfType<Guna2NumericUpDown>().ToList()[index];
                    nud.Value = 0;
                    nud.Enabled = false;
                }
            }
        }
        private void Btn_Money_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button btn_Money)
            {
                if (btn_Money.Name == "btn_10q")
                {
                    all_Price += 0.1;
                    lbl_Enter_Price.Text = all_Price.ToString() + " AZN";
                    var price = all_Price - odenilmeli_mebleg;
                    if (price >= 0)
                    {
                        lbl_Residue_Price.Text = price.ToString() + " AZN";
                        btn_End.Enabled = true;
                    }
                    else
                        lbl_Residue_Price.Text = "0,00 AZN";
                }
                else if (btn_Money.Name == "btn_20q")
                {
                    all_Price += 0.2;
                    lbl_Enter_Price.Text = all_Price.ToString() + " AZN";
                    var price = all_Price - odenilmeli_mebleg;
                    if (price >= 0)
                    {
                        lbl_Residue_Price.Text = price.ToString() + " AZN";
                        btn_End.Enabled = true;
                    }
                    else
                        lbl_Residue_Price.Text = "0,00 AZN";
                }
                else if (btn_Money.Name == "btn_50q")
                {
                    all_Price += 0.5;
                    lbl_Enter_Price.Text = all_Price.ToString() + " AZN";
                    var price = all_Price - odenilmeli_mebleg;
                    if (price >= 0)
                    {
                        lbl_Residue_Price.Text = price.ToString() + " AZN";
                        btn_End.Enabled = true;
                    }
                    else
                        lbl_Residue_Price.Text = "0,00 AZN";
                }
                else if (btn_Money.Name == "btn_1azn")
                {
                    all_Price += 1.0;
                    lbl_Enter_Price.Text = all_Price.ToString() + " AZN";
                    var price = all_Price - odenilmeli_mebleg;
                    if (price >= 0)
                    {
                        lbl_Residue_Price.Text = price.ToString() + " AZN";
                        btn_End.Enabled = true;
                    }
                    else
                        lbl_Residue_Price.Text = "0,00 AZN";
                }
                else if (btn_Money.Name == "btn_5azn")
                {
                    all_Price += 5.0;
                    lbl_Enter_Price.Text = all_Price.ToString() + " AZN";
                    var price = all_Price - odenilmeli_mebleg;
                    if (price >= 0)
                    {
                        lbl_Residue_Price.Text = price.ToString() + " AZN";
                        btn_End.Enabled = true;
                    }
                    else
                        lbl_Residue_Price.Text = "0,00 AZN";
                }
                else if (btn_Money.Name == "btn_10azn")
                {
                    all_Price += 10.0;
                    lbl_Enter_Price.Text = all_Price.ToString() + " AZN";
                    var price = all_Price - odenilmeli_mebleg;
                    if (price >= 0)
                    {
                        lbl_Residue_Price.Text = price.ToString() + " AZN";
                        btn_End.Enabled = true;
                    }
                    else
                        lbl_Residue_Price.Text = "0,00 AZN";
                }
                else
                    throw new NotImplementedException("Not found money!");
            }
        }
        private void Tb_Enter_Price_TextChanged(object sender, EventArgs e)
        {
            if (tb_Enter_Price.Text != string.Empty)
            {
                enter_Price = double.Parse(tb_Enter_Price.OnlyDecimalNumberTextBox());
                lbl_Enter_Price.Text = enter_Price.ToString() + " AZN";
                var price = enter_Price - odenilmeli_mebleg;
                if (price >= 0)
                {
                    lbl_Residue_Price.Text = price.ToString() + " AZN";
                    btn_End.Enabled = true;
                }
                else
                    lbl_Residue_Price.Text = "0,00 AZN";
            }
            else
            {
                lbl_Enter_Price.Text = "0,00 AZN";
                lbl_Residue_Price.Text = "0,00 AZN";

            }
        }
        private void Btn_Calculate_Click(object sender, EventArgs e)
        {
            double allColaPrice = 0, allFantaPrice = 0, allIceTeaPrice = 0, allPepsiPrice = 0, allBreadPrice = 0, allSnickersPrice = 0, allTwixPrice = 0, allBountyPrice = 0
                , allPopkekPrice = 0, allMarsPrice = 0, allColgatePrice = 0, allSmokePrice = 0;
            if (cb_Cola.Checked)
            {
                allColaPrice = cola.Price * ((int)nud_Cola.Value);
                cola.StockCount -= ((int)nud_Cola.Value);
                lbl_SCount_Cola.Text = cola.StockCount.ToString();
            }
            if (cb_Fanta.Checked)
            {
                allFantaPrice = fanta.Price * ((int)nud_Fanta.Value);
                fanta.StockCount -= ((int)nud_Fanta.Value);
                lbl_SCount_Fanta.Text = fanta.StockCount.ToString();
            }
            if (cb_Icetea.Checked)
            {
                allIceTeaPrice = icetea.Price * ((int)nud_Lipton.Value);
                icetea.StockCount -= ((int)nud_Lipton.Value);
                lbl_SCount_Icetea.Text = icetea.StockCount.ToString();
            }
            if (cb_Pepsi.Checked)
            {
                allPepsiPrice = pepsi.Price * ((int)nud_Pepsi.Value);
                pepsi.StockCount -= ((int)nud_Pepsi.Value);
                lbl_SCount_Pepsi.Text = pepsi.StockCount.ToString();
            }
            if (cb_Bread.Checked)
            {
                allBreadPrice = bread.Price * ((int)nud_Bread.Value);
                bread.StockCount -= ((int)nud_Bread.Value);
                lbl_SCount_Bread.Text = bread.StockCount.ToString();
            }
            if (cb_Snickers.Checked)
            {
                allSnickersPrice = snickers.Price * ((int)nud_Snickers.Value);
                snickers.StockCount -= ((int)nud_Snickers.Value);
                lbl_SCount_Snickers.Text = snickers.StockCount.ToString();
            }
            if (cb_Twix.Checked)
            {
                allTwixPrice = twix.Price * ((int)nud_Twix.Value);
                twix.StockCount -= ((int)nud_Twix.Value);
                lbl_SCount_Twix.Text = twix.StockCount.ToString();
            }
            if (cb_Bounty.Checked)
            {
                allBountyPrice = bounty.Price * ((int)nud_Bounty.Value);
                bounty.StockCount -= ((int)nud_Bounty.Value);
                lbl_SCount_Bounty.Text = bounty.StockCount.ToString();
            }
            if (cb_Popkek.Checked)
            {
                allPopkekPrice = popkek.Price * ((int)nud_Popkek.Value);
                popkek.StockCount -= ((int)nud_Popkek.Value);
                lbl_SCount_Popkek.Text = popkek.StockCount.ToString();
            }
            if (cb_Mars.Checked)
            {
                allMarsPrice = mars.Price * ((int)nud_Mars.Value);
                mars.StockCount -= ((int)nud_Mars.Value);
                lbl_SCount_Mars.Text = mars.StockCount.ToString();
            }
            if (cb_Colgate.Checked)
            {
                allColgatePrice = colgate.Price * ((int)nud_Colgate.Value);
                colgate.StockCount -= ((int)nud_Colgate.Value);
                lbl_SCount_Colgate.Text = colgate.StockCount.ToString();
            }
            if (cb_Smoke.Checked)
            {
                allSmokePrice = smoke.Price * ((int)nud_Marlboro.Value);
                smoke.StockCount -= ((int)nud_Marlboro.Value);
                lbl_SCount_Smoke.Text = smoke.StockCount.ToString();
            }
            odenilmeli_mebleg = allBountyPrice + allBreadPrice + allColaPrice + allColgatePrice + allFantaPrice + allIceTeaPrice + allMarsPrice + allPepsiPrice + allPopkekPrice + allSmokePrice + allSnickersPrice + allTwixPrice;
            if (odenilmeli_mebleg == 0)
                MessageBox.Show("Hec bir mehsul secilmedi!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                tb_Enter_Price.Enabled = true;
                pb_10q.Visible = false;
                pb_20q.Visible = false;
                pb_50q.Visible = false;
                image_1azn.Visible = false;
                image_5azn.Visible = false;
                image_10azn.Visible = false;

                btn_10azn.Visible = true;
                btn_10q.Visible = true;
                btn_1azn.Visible = true;
                btn_20q.Visible = true;
                btn_50q.Visible = true;
                btn_5azn.Visible = true;
                lbl_All_Price.Text = odenilmeli_mebleg.ToString() + " AZN";
                btn_Calculate.Visible = false;
                lbl_All_Price.Visible = true;
                guna2HtmlLabel13.Visible = true;
                Controls.OfType<Guna2CustomCheckBox>().ToList().ForEach(cb => cb.Enabled = false);
                Controls.OfType<Guna2NumericUpDown>().ToList().ForEach(nud => nud.Enabled = false);
            }
        }
        private void Btn_End_Click(object sender, EventArgs e)
        {
            decimal productCount;
            btn_End.Enabled = false;
            btn_Save.Enabled = true;
            for (int i = Controls.OfType<Guna2CustomCheckBox>().Count() - 1, j = 0; i >= 0; i--, j++)
            {
                if (Controls.OfType<Guna2CustomCheckBox>().ToList()[i].Checked == true)
                {
                    productCount = Controls.OfType<Guna2NumericUpDown>().ToList()[i].Value;
                    richTextBox1.Text += Controls.OfType<Guna2CustomCheckBox>().ToList()[i].Name.Substring(3) + $" - {productCount}\n";
                    richText.Text += $"  {Controls.OfType<Guna2CustomCheckBox>().ToList()[i].Name.Substring(3)}                                                   " +
                        $"{productCount}\n";
                }
            }
            richText.Text += $"                       **********************************************" +
                $"\nThe final amount                                                       {lbl_All_Price.Text}" +
                $"\n                       **********************************************" +
                $"\nThe balance was returned                                       {lbl_Residue_Price.Text}" +
                $"\n                       **********************************************" +
                 "\n                       ---------------------- Attention --------------------" +
                $"\nPRODUCT RETURN IS POSSIBLE FOR 15 DAYS ONLY WITH PURCHASE RECEIPT AND POSTERMINAL SLIBI";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(richText.Text);
            richText.Text = System.Text.Encoding.UTF8.GetString(bytes);
        }
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A6.Rotate());
                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();
                        doc.Add(new iTextSharp.text.Paragraph(richText.Text));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        doc.Close();
                    }
                }
            }
            btn_Save.Enabled = false;
        }
    }
}




