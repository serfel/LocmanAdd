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
using System;
using System.Collections;

// This class implements the collection for the MergeFields
// It contains the standard methods and properties for collections
public class MergeFieldCollection : CollectionBase, IEnumerable, IEnumerator {

    private int index = -1;

    public MergeFieldCollection() {
        this.index = -1;
    }

    public void Add(MergeField mergeField) {
        this.List.Add(mergeField);
    }

    public void Remove(MergeField mergeField) {
        this.List.Remove(mergeField);
    }

    public MergeField this[int index] {
        get {
            return (MergeField)this.List[index];
        }
        set {
            this.List[index] = value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return this;
    }

    public Object Current {
        get {
            return this.List[index];
        }
    }

    public bool MoveNext() {
        this.index++;
        return (this.index < this.List.Count);
    }

    public void Reset() {
        this.index = -1;
    }
}

