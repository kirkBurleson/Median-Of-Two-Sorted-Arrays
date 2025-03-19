public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
	var temp = new int[nums1.Length + nums2.Length];
	var result = 0.0;
	int n1 = 0;
	int n2 = 0;
	int count = 0;

	// iterate with pointers and merge into temp array
	while (n1 < nums1.Length && n2 < nums2.Length)
	{
		// one of the arrays is empty so skip the merging
		if (nums1.Length == 0 || nums2.Length == 0) { break; }

		// get current numbers
		var n1_number = nums1[n1];
		var n2_number = nums2[n2];

		// do the merging
		if (n1_number < n2_number)
		{
			temp[count++] = n1_number;
			n1++;
		}
		else if (n2_number < n1_number)
		{
			temp[count++] = n2_number;
			n2++;
		}
		else
		{
			temp[count++] = n1_number;
			temp[count++] = n2_number;
			n1++;
			n2++;
		}
	}

	// copy remaining elements
	while (n1 < nums1.Length) { temp[count++] = nums1[n1++]; }
	while (n2 < nums2.Length) { temp[count++] = nums2[n2++]; }

	// find median
	double middle = (double)temp.Length / 2;

	// it's even
	// if middle is 1, that means one array is empty
	// and the other has 2 elements. Special case.
	if (temp.Length % 2 == 0 || middle == 1)
	{
		result = ((double)(temp[(int)middle - 1] + temp[(int)middle])) / 2;
	}
	// it's odd
	else
	{
		result = temp[(int)middle];
	}

	return result;
}