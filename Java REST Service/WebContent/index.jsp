<!-- 

 Travel Experts Online Backoffice
 Web App for agents to maintain the database
 
 Logic code: Tom Hollis
 User Experience: Chris Yamez

 April/May 2020
 -->


<%@ include file="header.jsp" %>
<script src="js/ajax.js"></script>
<body class="container-fluid">

	<header class="jumbotron">
		<h1>Travel Experts Agent Backoffice</h1>
		<div>Data maintenance tool for agents</div>
		<!-- get a list of tables and display here in dropdown -->
		<select id="allTables" onchange=getTable()>
			<option value="">Select a table</option>
			<option value="Agency">Agencies</option> 
			<option value="Agent">Agents</option> 
			<option value="Bookingdetail">Bookingdetails</option> 
			<option value="Booking">Bookings</option> 
			<option value="Customer">Customers</option> 
			<option value="Package">Packages</option> 
		</select>
	</header>
<!-- then two divs: left side a list of everything in that table, right side a detail view that populates when one is clicked -->
  <!-- responsiveness: when screen is narrower than wide, list should go above detail -->
  <!-- or they replace each other, or the detail view is a modal pop-up whatever looks good and can be done -->
	<main class="row"">
		<div class="col-md-6" id="listing">
		  <table id="listTable" >
		  </table>
		</div>
		<div class="col-md-6" id="details">
		  <fieldset id="detailsForm">		    
		  </fieldset>
		</div>
	 </main>
</body>
</html>