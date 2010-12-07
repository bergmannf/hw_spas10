<?php
session_start();
if (isset($_SESSION['customer']))
{
	// If the customer is logged in we redirect to the customer page.
	header('customer.php');
}
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
		<title>Homepage</title>
	</head>
    	<?php include 'includes/menu.inc.php'; ?>
	<body>
		<form id="login" method="post" action="./php/customer.php">
			<p>
				<label for="customerId">CustomerId:</label>
				<input name="customerId" id="customerId" type="text" class="text"/>
			</p>
			<button id="submitButton" name="submitButton" type="submit">Submit</button>
		</form>
	</body>
</html>
