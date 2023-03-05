namespace Hero_UnitTest.Helpers;

public class Algorithm
{
    public int RemoveDuplicates(int[] nums)
    {
        int i = 1;
        foreach(var n in nums)
            if(n > nums[i - 1])
                nums[i++] = n;
        
        return i;
    }
    
    public string LargestNumber(int[] nums) 
    {
        if(nums.All(x => x == 0)) return "0";

        var s = nums.Select(x => x.ToString()).ToList();

        s.Sort((a, b) => (b+a).CompareTo(a+b));

        return string.Concat(s);
    }
}