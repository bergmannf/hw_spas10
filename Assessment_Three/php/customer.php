<?php
session_start();
?>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<title>Customer details</title>
	</head>
	<?php include './includes/menu.inc.php'; ?>
	<body>
		<?php
		$customerId = $_POST['customerId'];
		if (isset($customerId)) {
			$_SESSION['customer'] = $customerId;
		} else {
			header('../index.php');
		}
		// TODO acquire customer information from database
		?>
	</body>
</html>
