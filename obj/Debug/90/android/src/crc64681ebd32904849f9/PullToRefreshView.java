package crc64681ebd32904849f9;


public class PullToRefreshView
	extends android.widget.ProgressBar
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getProgress:()I:GetGetProgressHandler\n" +
			"n_setProgress:(I)V:GetSetProgress_IHandler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.SfDataGrid.PullToRefreshView, Syncfusion.SfDataGrid.Android", PullToRefreshView.class, __md_methods);
	}


	public PullToRefreshView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == PullToRefreshView.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.PullToRefreshView, Syncfusion.SfDataGrid.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public PullToRefreshView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == PullToRefreshView.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.PullToRefreshView, Syncfusion.SfDataGrid.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public PullToRefreshView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == PullToRefreshView.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.PullToRefreshView, Syncfusion.SfDataGrid.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public PullToRefreshView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == PullToRefreshView.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.PullToRefreshView, Syncfusion.SfDataGrid.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public int getProgress ()
	{
		return n_getProgress ();
	}

	private native int n_getProgress ();


	public void setProgress (int p0)
	{
		n_setProgress (p0);
	}

	private native void n_setProgress (int p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
