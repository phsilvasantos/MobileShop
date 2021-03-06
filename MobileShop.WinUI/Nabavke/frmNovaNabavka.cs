﻿using MobileShop.Model.Models;
using MobileShop.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileShop.WinUI.Nabavke
{
    public partial class frmNovaNabavka : Form
    {
        private readonly APIService _serviceDobavljaci = new APIService("Dobavljaci");
        private readonly APIService _serviceKorisnici = new APIService("Korisnici");
        private readonly APIService _serviceSkladista = new APIService("Skladista");
        private readonly APIService _serviceArtikli = new APIService("Artikli");
        private readonly APIService _serviceNabavke = new APIService("Nabavke");

        private NabavkeInsertRequest request = new NabavkeInsertRequest();

        private decimal Iznos = 0;
        private const decimal Pdv = 0.17M;
        private decimal IznosPdv = 0;

        public frmNovaNabavka()
        {
            InitializeComponent();
            dgvStavkeNabavke.AutoGenerateColumns = false;
            
        }

        private void TxtBrojNabavke_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private async void FrmNovaNabavka_Load(object sender, EventArgs e)
        {
            List<Model.Models.Dobavljaci> dobavljaci_result = await _serviceDobavljaci.Get<List<Model.Models.Dobavljaci>>(null);

            dobavljaci_result.Insert(0, new Model.Models.Dobavljaci());
            cmbDobavljaci.DataSource = dobavljaci_result;
            cmbDobavljaci.DisplayMember = "Naziv";
            cmbDobavljaci.ValueMember = "DobavljacId";

            List<Model.Models.Korisnici> korisnici_result = await _serviceKorisnici.Get<List<Model.Models.Korisnici>>(null);

            korisnici_result.Insert(0, new Model.Models.Korisnici());
            cmbKorisnici.DataSource = korisnici_result;
            cmbKorisnici.DisplayMember = "KorisnickoIme";
            cmbKorisnici.ValueMember = "KorisnikId";

            List<Model.Models.Skladista> skladista_result = await _serviceSkladista.Get<List<Model.Models.Skladista>>(null);

            skladista_result.Insert(0, new Model.Models.Skladista());
            cmbSkladista.DataSource = skladista_result;
            cmbSkladista.DisplayMember = "Naziv";
            cmbSkladista.ValueMember = "SkladisteId";



        }

        private async void BtnDodaj_Click(object sender, EventArgs e)
        {
            Artikli artikal = await _serviceArtikli.GetBySifra<Artikli>(txtSifra.Text);

            if (artikal == null)
            {
                MessageBox.Show("Nije pronadjen artikal sa tom sifrom");
            }
            else
            {
                bool postoji = false;
                foreach(var item in request.stavke)
                {
                    if (item.Sifra == artikal.Sifra)
                    {
                        MessageBox.Show("Artikal sa ovom sifrom je vec dodan");
                        postoji = true;
                    }
                    
                }
                if (postoji == false)
                {
                    StavkeNabavkeInsertRequest stavka = new StavkeNabavkeInsertRequest();
                    stavka.ArtikalId = artikal.ArtikalId;
                    stavka.Artikal = artikal.Naziv;
                    stavka.Sifra = artikal.Sifra;
                    stavka.Kolicina = int.Parse(txtKolicina.Text);
                    stavka.Cijena = decimal.Parse(txtCijena.Text);

                    
                    Iznos += stavka.Cijena * stavka.Kolicina;
                    IznosPdv = Iznos * Pdv;

                    txtIznosRacuna.Text = Math.Round(Iznos + IznosPdv,2).ToString() + " KM";
                    txtPDV.Text = Math.Round(IznosPdv,2).ToString() + " KM";



                    request.stavke.Add(stavka);

                    dgvStavkeNabavke.DataSource = request.stavke.ToList();

                }
            }


            
        }

        private void BtnZakljuci_Click(object sender, EventArgs e)
        {
            request.BrojNabavke = txtBrojNabavke.Text;
            request.Datum = dtpDatum.Value;
            request.DobavljacId = int.Parse(cmbDobavljaci.SelectedValue.ToString());
            request.KorisnikId = int.Parse(cmbKorisnici.SelectedValue.ToString());
            request.Napomena = txtNapomena.Text;
            request.SkladisteId = int.Parse(cmbSkladista.SelectedValue.ToString());
            request.IznosRacuna = Iznos + IznosPdv;
            request.Pdv = IznosPdv;


            _serviceNabavke.Insert<Model.Models.Nabavke>(request);

            MessageBox.Show("Nabavka zakljucena");



        }
    }
}
