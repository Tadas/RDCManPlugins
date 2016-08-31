using RdcMan;
using System.Windows.Forms;
using System.Xml;
using System.ComponentModel.Composition;

namespace Plugin.Sample
{
    [Export(typeof(IPlugin))]
    public class PluginSample : IPlugin
    {
        public void OnContextMenu(System.Windows.Forms.ContextMenuStrip contextMenuStrip, RdcTreeNode node)
        {
            MessageBox.Show("OnContextMenu", "Plugin.Sample event", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void OnDockServer(ServerBase server)
        {
            MessageBox.Show("OnDockServer", "Plugin.Sample event", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void OnUndockServer(IUndockedServerForm form)
        {
            MessageBox.Show("OnUndockServer", "Plugin.Sample event", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void PostLoad(IPluginContext context)
        {
            MessageBox.Show("PostLoad", "Plugin.Sample event", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void PreLoad(IPluginContext context, XmlNode xmlNode)
        {
            MessageBox.Show("PreLoad", "Plugin.Sample event", MessageBoxButtons.OK ,MessageBoxIcon.Information);
        }

        public XmlNode SaveSettings()
        {
            MessageBox.Show("SaveSettings", "Plugin.Sample event", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }

        public void Shutdown()
        {
            MessageBox.Show("Shutdown", "Plugin.Sample event", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
