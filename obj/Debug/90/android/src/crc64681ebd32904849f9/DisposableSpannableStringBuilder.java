package crc64681ebd32904849f9;


public class DisposableSpannableStringBuilder
	extends android.text.SpannableStringBuilder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_finalize:()V:GetJavaFinalizeHandler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.SfDataGrid.DisposableSpannableStringBuilder, Syncfusion.SfDataGrid.Android", DisposableSpannableStringBuilder.class, __md_methods);
	}


	public DisposableSpannableStringBuilder ()
	{
		super ();
		if (getClass () == DisposableSpannableStringBuilder.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.DisposableSpannableStringBuilder, Syncfusion.SfDataGrid.Android", "", this, new java.lang.Object[] {  });
	}


	public DisposableSpannableStringBuilder (java.lang.CharSequence p0)
	{
		super (p0);
		if (getClass () == DisposableSpannableStringBuilder.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.DisposableSpannableStringBuilder, Syncfusion.SfDataGrid.Android", "Java.Lang.ICharSequence, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public DisposableSpannableStringBuilder (java.lang.CharSequence p0, int p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == DisposableSpannableStringBuilder.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.DisposableSpannableStringBuilder, Syncfusion.SfDataGrid.Android", "Java.Lang.ICharSequence, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}

	public DisposableSpannableStringBuilder (java.lang.String p0)
	{
		super ();
		if (getClass () == DisposableSpannableStringBuilder.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.DisposableSpannableStringBuilder, Syncfusion.SfDataGrid.Android", "System.String, mscorlib", this, new java.lang.Object[] { p0 });
	}

	public DisposableSpannableStringBuilder (java.lang.String p0, int p1, int p2)
	{
		super ();
		if (getClass () == DisposableSpannableStringBuilder.class)
			mono.android.TypeManager.Activate ("Syncfusion.SfDataGrid.DisposableSpannableStringBuilder, Syncfusion.SfDataGrid.Android", "System.String, mscorlib:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void finalize ()
	{
		n_finalize ();
	}

	private native void n_finalize ();

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
