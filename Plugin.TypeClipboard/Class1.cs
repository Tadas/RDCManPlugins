using RdcMan;
using System.Windows.Forms;
using System.Xml;
using System.ComponentModel.Composition;
using System.Reflection;
using System;
using System.Text.RegularExpressions;

namespace Plugin.TypeClipboard
{
    [Export(typeof(IPlugin))]
    public class TypeClipboard : IPlugin
    {
        Server TargetServer = null;
 
        public void OnContextMenu(System.Windows.Forms.ContextMenuStrip contextMenuStrip, RdcTreeNode node)
        {
            if ((node as GroupBase) == null)
            {
                if ((node as ServerBase) != null)
                {
                    this.TargetServer = node as Server;
                    ToolStripMenuItem NewMenuItem = new DelegateMenuItem("Type clipboard text", MenuNames.None, () => this.TypeClipboardText());
                    //NewMenuItem.Image = Properties.Resources.PowerShell5_32;

                    contextMenuStrip.Items.Insert(contextMenuStrip.Items.Count - 1, NewMenuItem);
                    contextMenuStrip.Items.Insert(contextMenuStrip.Items.Count - 1, new ToolStripSeparator());
                }
            }
        }

        public void OnDockServer(ServerBase server)
        {
            //MessageBox.Show("OnDockServer", "Plugin.TypeClipboard event", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void OnUndockServer(IUndockedServerForm form)
        {
            //MessageBox.Show("OnUndockServer", "Plugin.TypeClipboard event", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void PostLoad(IPluginContext context)
        {
            //MessageBox.Show("PostLoad", "Plugin.TypeClipboard event", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void PreLoad(IPluginContext context, XmlNode xmlNode)
        {
            //MessageBox.Show("PreLoad", "Plugin.TypeClipboard event", MessageBoxButtons.OK ,MessageBoxIcon.Information);
        }

        public XmlNode SaveSettings()
        {
            //MessageBox.Show("SaveSettings", "Plugin.TypeClipboard event", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }

        public void Shutdown()
        {
            //MessageBox.Show("Shutdown", "Plugin.TypeClipboard event", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void TypeClipboardText()
        {
            if(!this.TargetServer.IsConnected) {
                //MessageBox.Show("Not connected...", "Not connected...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MethodInfo FocusMethod = this.TargetServer.GetType().GetMethod("Focus", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            FocusMethod.Invoke(this.TargetServer, null);

            string StuffToType = Clipboard.GetText();
            //MessageBox.Show(StuffToType, "StuffToType", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Escape special chars which SendKeys is looking for:
            // https://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys(v=vs.110).aspx
            string StuffToTypeEscaped = Regex.Replace(StuffToType, "[+^%~(){}]", "{$0}");

            // Replace newlines with enter
            StuffToTypeEscaped = Regex.Replace(StuffToTypeEscaped, "\r\n?", "~");

            //MessageBox.Show(StuffToTypeEscaped, "StuffToTypeEscaped", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SendKeys.SendWait(StuffToTypeEscaped);
        }
    }
}
