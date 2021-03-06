﻿using MobileShop.WinUI.Korisnici;
using MobileShop.WinUI.Nabavke;
using MobileShop.WinUI.Zahtjevi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MobileShop.WinUI.Obavijesti;
using MobileShop.WinUI.Narudzbe;
using MobileShop.WinUI.Izvjestaji;
using Tulpep.NotificationWindow;

namespace MobileShop.WinUI
{
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;
        private readonly APIService _service = new APIService("PoslanaNarudzba");
        private readonly APIService _serviceNarudzba = new APIService("Narudzbe");

        private int Id = 0;
        public frmIndex()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        //private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        //}

        //private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        //}

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void PregledZahtjevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmZahtjevi frm = new frmZahtjevi();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void ListaKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisnici frm = new frmKorisnici();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void NoviKorisnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisniciDetalji frm = new frmKorisniciDetalji();
            frm.Show();
        }

        private void PregledDetaljaNabavkeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNabavke frm = new frmNabavke();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void ListaObavijestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmObavijesti frm = new frmObavijesti();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void PostaviNovuObavijestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNovaObavijest frm = new frmNovaObavijest();
            frm.Show();
        }

        private void NarudzbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void ListaNarudzbiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmNarudzbe frm = new frmNarudzbe();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();

        }

        private void DetaljiNarudzbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void PregledIzvjestajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIzvjestajiIndex frm = new frmIzvjestajiIndex();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private async void FrmIndex_Load(object sender, EventArgs e)
        {

            var lista = await _service.Get<List<Model.Models.PoslanaNarudzba>>(null);
            

            List<Model.Models.PoslanaNarudzba> result = new List<Model.Models.PoslanaNarudzba>();

            foreach (var item in lista)
            {

                if (item.Poslano == false)
                {
                    result.Add(item);

                    var search = new Model.Requests.PoslanaNarudzbaUpdateRequest()
                    {
                        Poslano = true
                    };

                    _service.Update<Model.Models.PoslanaNarudzba>(item.PoslanaNarudzbaId, search);

                }
            }

            foreach (var notifikacija in result)
            {
                Model.Models.Narudzbe Narudzba = await _serviceNarudzba.GetById<Model.Models.Narudzbe>(notifikacija.NarudzbaId);

                Id = Narudzba.NarudzbaId;

                PopupNotifier popup = new PopupNotifier();
                popup.AnimationDuration = 6000;
                popup.Image = Properties.Resources.Info;
                popup.TitleText = "Notifikacija o narudzbi                         " + notifikacija.Datum.ToShortDateString();
                popup.ContentText = "Narudzba sa brojem narudzbe '" + Narudzba.BrojNarudzbe + "' je pristigla na odrediste!";
                popup.ShowOptionsButton = true;
                popup.OptionsMenu = options;
                popup.ShowCloseButton = true;
             

                popup.Popup();

                
                



            }



        }

        private void DetaljiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                frmNarudzbeDetalji frm = new frmNarudzbeDetalji(Id);
                frm.Show();
            }
            
        }

        private void OKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
