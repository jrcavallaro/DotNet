<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDate.aspx.cs" Inherits="KnockoutJS.Basics01.ShowDate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/knockout-2.2.1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<p>Day: <input data-bind="value: day" /></p>
		<p>Month: <input data-bind="value: month" /></p>
		<p>Year: <input data-bind="value: year" /></p>
		<p>The current date is <span data-bind="text: fullDate"></span></p>
    </div>
	<div>
		<p>Months until December: <span data-bind="text: MonthsUntilDec" /></p>
	</div>
	<div>
		<ul data-bind="foreach: months">
			<li>
				<b data-bind="text: $data"></b>
			</li>
		</ul>
	</div>
    </form>
</body>
</html>

<script type="text/javascript">

	function ViewModel() {

		this.day = ko.observable('24');
		this.month = ko.observable('02');
		this.year = ko.observable('2012');
		this.MonthsUntilDec = ko.observable('');
		this.months = ko.observable('');
		var today = new Date();
		var monthsArray = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov'];

		this.fullDate = ko.computed(
			function () {
				return this.day() + "/" + this.month() + "/" + this.year();
			},
			this
		);

		this.MonthsUntilDec = ko.computed(
			function() {
				return 12 - (today.getMonth() + 2);
			},
			this
		);

		this.months = ko.computed(
			function() {
				var ms = new Array();
				var i = 0;
				for (var x = today.getMonth() + 1; x < 12; x++) {
					ms[i++] = monthsArray[x];
				}
				return ms;
			},
			this
		);
	};

	ko.applyBindings(new ViewModel());

</script>
