﻿@model List<StarIndiaHoliday.Models.IndexEnquiry>

<table width="100%" border="0" cellspacing="0" cellpadding="0" class="admintable">
    <tr>
        <th width="45" align="left" valign="middle">Sr.No.</th>
        <th width="73" align="left" valign="middle">Name</th>
        <th width="75" align="left" valign="middle">Email</th>
        <th width="62" align="left" valign="middle">Mobile Number</th>
        <th width="200" align="left" valign="middle">Message</th>
    </tr>
@{int i = 0;}

@foreach (var item in Model)
{
    i = i + 1;
    <tr>
        <td align="left" valign="top">@i.ToString()</td>
        <td align="left" valign="top">@item.Name</td>
        <td align="left" valign="top">@item.Email</td>
        <td align="left" valign="top">@item.Mobile</td>
        <td align="left" valign="top">@item.Message</td>
    </tr>
}
</table>




    @model List<StarIndiaHoliday.Models.ContactusEnquiry>

<table width="100%" border="0" cellspacing="0" cellpadding="0" class="admintable">
    <tr>
        <th width="45" align="left" valign="middle">Sr.No.</th>
        <th width="73" align="left" valign="middle">Name</th>
        <th width="75" align="left" valign="middle">Email</th>
        <th width="62" align="left" valign="middle">Mobile Number</th>
        <th width="200" align="left" valign="middle">Message</th>
        <th width="200" align="left" valign="middle">Enquiry For</th>
    </tr>
@{int i = 0;}

@foreach (var item in Model)
{
    i = i + 1;
    <tr>
        <td align="left" valign="top">@i.ToString()</td>
        <td align="left" valign="top">@item.Name</td>
        <td align="left" valign="top">@item.Email</td>
        <td align="left" valign="top">@item.Mobile</td>
        <td align="left" valign="top">@item.Message</td>
        <td align="left" valign="top">@item.EnquiryFor</td>
    </tr>
}
</table>


    public class ContactusEnquiry
    {
      public string Name { get; set; }
      public string Email { get; set; }
      public string Mobile { get; set; }
      public string Message { get; set; }
      public string EnquiryFor { get; set; }
    }

	

    public class IndexEnquiry
    {
      public string Name { get; set; }
      public string Email { get; set; }
      public string Mobile { get; set; }
      public string Message { get; set; }
    }