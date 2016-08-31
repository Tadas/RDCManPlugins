using RdcMan;
using System.ComponentModel.Composition;
using System.Xml;
using System.Windows.Forms;
using System;

namespace Plugin.EnterPSSession
{
    [Export(typeof(IPlugin))]
    public class PluginEnterPSSession : IPlugin
    {
        private string TargetHost;

        public void OnContextMenu(System.Windows.Forms.ContextMenuStrip contextMenuStrip, RdcTreeNode node)
        {
            if ((node as GroupBase) == null)
            {
                if ((node as ServerBase) != null)
                {
                    this.TargetHost = (node as ServerBase).ServerName;
                    ToolStripMenuItem NewMenuItem = new DelegateMenuItem("Enter-PSSession", MenuNames.None, () => this.EnterPSSession());
                    NewMenuItem.Image = Properties.Resources.PowerShell5_32;

                    contextMenuStrip.Items.Insert(contextMenuStrip.Items.Count - 1, NewMenuItem);
                    contextMenuStrip.Items.Insert(contextMenuStrip.Items.Count - 1, new ToolStripSeparator());
                }
            }
        }

        public void OnDockServer(ServerBase server)
        {
        }

        public void OnUndockServer(IUndockedServerForm form)
        {
        }

        public void PostLoad(IPluginContext context)
        {
        }

        public void PreLoad(IPluginContext context, XmlNode xmlNode)
        {
        }

        public XmlNode SaveSettings()
        {
            return null;
        }

        public void Shutdown()
        {
        }

        public void EnterPSSession()
        {
            string PSpath = System.IO.Path.Combine(Environment.SystemDirectory, "WindowsPowerShell\\v1.0\\powershell.exe");
            string Arguments = "-NoLogo -NoExit Enter-PSSession " + this.TargetHost;

            //MessageBox.Show(PSpath + " " + Arguments, "Starting PSSession", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start(PSpath, Arguments);
        }
    }
}
