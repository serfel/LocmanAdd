/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Mail Merge Sample
** description:	Shows how to use the DocumentServer.MailMerge class in Windows Forms projects 
**              to merge TXTextControl.ApplicationFields in template documents with data from 
**              various data sources. The MailMerge class encapsulates powerful mail merge 
**              capabilities in a ready-to-use component. The DocumentServer.MailMerge class 
**              is part of the TXTextControl.DocumentServer namespace.
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/

// This class synchronizes the MergeFieldCollection with the
// TextControl's ApplicationField collection
public class CollectionSync {

    // Member variables
    public TXTextControl.TextControl m_tx;
    private MergeFieldCollection m_mergeFieldCollection;

    // The constructor has 2 parameters: The TextControl instance and the MergeFieldCollection
    // that should be synchronized
    public CollectionSync(TXTextControl.TextControl TX, MergeFieldCollection MergeFieldCollection) {
        m_tx = TX;
        m_mergeFieldCollection = MergeFieldCollection;

        SyncCollections();

        // Attach events to the parent TextControl where the collections are
        // getting synchronized automatically
        m_tx.TextFieldCreated += new TXTextControl.TextFieldEventHandler(m_tx_TextFieldCreated);
        m_tx.TextFieldDeleted += new TXTextControl.TextFieldEventHandler(m_tx_TextFieldDeleted);
    }

    public void SyncCollections() {
        if (m_tx.ApplicationFields == null)
            return;

        m_mergeFieldCollection.Clear();

        // Add a reference of the ApplicationField to the MergeFieldCollection
        foreach (TXTextControl.ApplicationField curField in m_tx.ApplicationFields) {
            if (curField.TypeName == "MERGEFIELD") {
                TXTextControl.ApplicationField thisField = curField;
                MergeField newMergeField = new MergeField(thisField);
                m_mergeFieldCollection.Add(newMergeField);
            }
        }
    }

    void m_tx_TextFieldCreated(object sender, TXTextControl.TextFieldEventArgs e) {
        SyncCollections();
    }

    void m_tx_TextFieldDeleted(object sender, TXTextControl.TextFieldEventArgs e) {
        SyncCollections();
    }
}
