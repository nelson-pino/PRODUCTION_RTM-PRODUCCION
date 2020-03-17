﻿namespace RitramaAPP.Clases
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    using RitramaAPP.form;
    using System.Windows.Forms;
    public class ReportsManager
    {
        public void Detalle_RC(string despacho) 
        {
            using (FrmReportViewCrystal frmReportView = new FrmReportViewCrystal())
            {
                ReportDocument reporte = new ReportDocument();
                TableLogOnInfos crtablelogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtablelogoninfo = new TableLogOnInfo();
                reporte.Load(Application.StartupPath + R.PATH_FILES.PATH_REPORTS_DETALLE_RC);
                reporte.SetParameterValue("NUMERO", despacho);
                Tables CrTables;
                CrTables = reporte.Database.Tables;
                ConnectionInfo ConexInfo = new ConnectionInfo
                {
                    ServerName = R.SERVERS.SERVER_ETIQUETAS,
                    DatabaseName = R.DATABASES.RITRAMA,
                    UserID = R.USERS.UserMaster,
                    Password = R.USERS.KeyMaster
                };
                foreach (Table table in CrTables)
                {
                    crtablelogoninfo = table.LogOnInfo;
                    crtablelogoninfo.ConnectionInfo = ConexInfo;
                    table.ApplyLogOnInfo(crtablelogoninfo);
                }
                frmReportView.crystalReportViewer1.ReportSource = reporte;
                frmReportView.Refresh();
                frmReportView.crystalReportViewer1.Zoom(80);
                frmReportView.Text = "DETALLE DE UNIQUE CODE (RC)";
                frmReportView.Width = 900;
                frmReportView.Height = 700;
                frmReportView.Refresh();
                frmReportView.ShowDialog();
            }
        }
        public void Detalle_Paleta(string despacho) 
        {
            using (FrmReportViewCrystal frmReportView = new FrmReportViewCrystal())
            {
                ReportDocument reporte = new ReportDocument();
                TableLogOnInfos crtablelogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtablelogoninfo = new TableLogOnInfo();
                reporte.Load(Application.StartupPath + R.PATH_FILES.PATH_REPORTS_DETALLE_PALETA);
                reporte.SetParameterValue("NUMERO", despacho);
                Tables CrTables;
                CrTables = reporte.Database.Tables;
                ConnectionInfo ConexInfo = new ConnectionInfo
                {
                    ServerName = R.SERVERS.SERVER_ETIQUETAS,
                    DatabaseName = R.DATABASES.RITRAMA,
                    UserID = R.USERS.UserMaster,
                    Password = R.USERS.KeyMaster
                };
                foreach (Table table in CrTables)
                {
                    crtablelogoninfo = table.LogOnInfo;
                    crtablelogoninfo.ConnectionInfo = ConexInfo;
                    table.ApplyLogOnInfo(crtablelogoninfo);
                }
                frmReportView.crystalReportViewer1.ReportSource = reporte;
                frmReportView.Refresh();
                frmReportView.crystalReportViewer1.Zoom(80);
                frmReportView.Text = "DETALLE DE PALETA";
                frmReportView.Width = 900;
                frmReportView.Height = 700;
                frmReportView.Refresh();
                frmReportView.ShowDialog();
            }
        }
        public void Conduce_Precio(string despacho) 
        {
            using (FrmReportViewCrystal frmReportView = new FrmReportViewCrystal())
            {
                ReportDocument reporte = new ReportDocument();
                TableLogOnInfos crtablelogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtablelogoninfo = new TableLogOnInfo();

                reporte.Load(Application.StartupPath + R.PATH_FILES.PATH_REPORTS_FORMAT_CONDUCE);
                
                reporte.SetParameterValue("NUMERO", despacho);

                Tables CrTables;
                CrTables = reporte.Database.Tables;

                ConnectionInfo ConexInfo = new ConnectionInfo
                {
                    ServerName = R.SERVERS.SERVER_ETIQUETAS,
                    DatabaseName = R.DATABASES.RITRAMA,
                    UserID = R.USERS.UserMaster,
                    Password = R.USERS.KeyMaster
                };

                foreach (Table table in CrTables)
                {
                    crtablelogoninfo = table.LogOnInfo;
                    crtablelogoninfo.ConnectionInfo = ConexInfo;
                    table.ApplyLogOnInfo(crtablelogoninfo);
                }

                frmReportView.crystalReportViewer1.ReportSource = reporte;
                frmReportView.crystalReportViewer1.Zoom(140);
                frmReportView.Text = "FORMATO CONDUCE CON PRECIO";
                frmReportView.Width = 900;
                frmReportView.Height = 700;
                frmReportView.ShowDialog();
            }
        }
        public void Conduce_sin_Precio(string despacho) 
        {
            using (FrmReportViewCrystal frmReportView = new FrmReportViewCrystal())
            {
                ReportDocument reporte = new ReportDocument();
                TableLogOnInfos crtablelogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtablelogoninfo = new TableLogOnInfo();
                reporte.Load(Application.StartupPath + R.PATH_FILES.PATH_REPORTS_FORMAT_CONDUCE_SP);
                reporte.SetParameterValue("NUMERO", despacho);
                ConnectionInfo ConexInfo = new ConnectionInfo
                {
                    ServerName = R.SERVERS.SERVER_ETIQUETAS,
                    DatabaseName = R.DATABASES.RITRAMA,
                    UserID = R.USERS.UserMaster,
                    Password = R.USERS.KeyMaster
                };
                Tables CrTables;
                CrTables = reporte.Database.Tables;
                foreach (Table table in CrTables)
                {
                    crtablelogoninfo = table.LogOnInfo;
                    crtablelogoninfo.ConnectionInfo = ConexInfo;
                    table.ApplyLogOnInfo(crtablelogoninfo);
                }
                frmReportView.crystalReportViewer1.ReportSource = reporte;
                frmReportView.crystalReportViewer1.Zoom(140);
                frmReportView.Text = "FORMATO CONDUCE SIN PRECIO";
                frmReportView.Width = 900;
                frmReportView.Height = 700;
                frmReportView.Refresh();
                frmReportView.ShowDialog();
            }
        }
    }
}