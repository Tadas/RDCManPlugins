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
            MessageBox.Show("OnContextMenu");
        }

        public void OnDockServer(ServerBase server)
        {
            MessageBox.Show("OnDockServer");
        }

        public void OnUndockServer(IUndockedServerForm form)
        {
            MessageBox.Show("OnUndockServer");
        }

        public void PostLoad(IPluginContext context)
        {
            MessageBox.Show("PostLoad");
        }

        public void PreLoad(IPluginContext context, XmlNode xmlNode)
        {
            MessageBox.Show("PreLoad");
        }

        public XmlNode SaveSettings()
        {
            MessageBox.Show("SaveSettings. I don't think this is called from anywhere");
            return null;
        }

        public void Shutdown()
        {
            MessageBox.Show("Shutdown");
        }
    }
}
