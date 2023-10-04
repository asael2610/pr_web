
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pr_web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Empleado empleado;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                empleado = new Empleado();
                empleado.drop_puesto(drop_puesto);
                empleado.grid_empleados(grid_empleados);
                
            }

        }

      

        protected void btn_crear_Click(object sender, EventArgs e)
        {
            empleado = new Empleado();
            if(empleado.crear(txt_codigo.Text,txt_nombres.Text,txt_apellidos.Text,txt_direccion.Text,txt_telefono.Text,txt_fn.Text,Convert.ToInt32 (drop_puesto.SelectedValue)) > 0)
            {
                lbl_mensaje.Text = "INGRESO EXITOSO...";
                empleado.grid_empleados(grid_empleados);
            }

        }

        protected void grid_empleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            //OBTENDREMOS TODOS LOS DATOS AL SELECCIONAR EL BOTON VER
            txt_codigo.Text = grid_empleados.SelectedRow.Cells[2].Text;
            txt_nombres.Text = grid_empleados.SelectedRow.Cells[3].Text;
            txt_apellidos.Text = grid_empleados.SelectedRow.Cells[4].Text;
            txt_direccion.Text = grid_empleados.SelectedRow.Cells[5].Text;
            txt_telefono.Text = grid_empleados.SelectedRow.Cells[6].Text;
            DateTime fecha = Convert.ToDateTime(grid_empleados.SelectedRow.Cells[7].Text); //yyyy-mm-dd
            txt_fn.Text = fecha.ToString("yyyy-MM-dd");
            int indice = grid_empleados.SelectedRow.RowIndex;
            drop_puesto.SelectedValue = grid_empleados.DataKeys[indice].Values["id_puesto"].ToString();
            btn_actualizar.Visible = true;

        }

        protected void grid_empleados_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            empleado = new Empleado();
            if (empleado.borrar(Convert.ToInt32(e.Keys["id"])) > 0)
            {
                lbl_mensaje.Text = "BORRADO EXITOSO...";
                empleado.grid_empleados(grid_empleados);
            }

        }

        protected void btn_actualizar_Click(object sender, EventArgs e)
        {

            empleado = new Empleado();
            if (empleado.actualizar(Convert.ToInt32(grid_empleados.SelectedValue), txt_codigo.Text, txt_nombres.Text, txt_apellidos.Text, txt_direccion.Text, txt_telefono.Text, txt_fn.Text, Convert.ToInt32(drop_puesto.SelectedValue)) > 0)
            {
                lbl_mensaje.Text = "ACTUALIZACION EXITOSA...";
                empleado.grid_empleados(grid_empleados);
            }

        }

        
    }
}