using InventoryApp.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp
{
    public partial class InventoryApp : Form
    {
        BLLProducto objetoCN = new BLLProducto();
        public InventoryApp()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            objetoCN.Create(int.Parse(textBoxCod.Text), float.Parse(textBoxValor.Text), textBoxProd.Text, textBoxDescrip.Text);
            MessageBox.Show("Se guardo correctamente el producto");
            viewAllProducts();
        }

        private void viewAllProducts()
        {
            BLLProducto objeto = new BLLProducto();
            dataGridView1.DataSource = objeto.View();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            viewAllProducts();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objetoCN.Delete(int.Parse(textBoxCod.Text));
            MessageBox.Show("Se elimino correctamente el producto");
            viewAllProducts();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            objetoCN.Update(int.Parse(textBoxCod.Text), float.Parse(textBoxValor.Text), textBoxProd.Text, textBoxDescrip.Text);
            MessageBox.Show("Se actualizo correctamente el producto");
            viewAllProducts();
        }
    }
}
