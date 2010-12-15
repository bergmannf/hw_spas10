<?php
require('./includes/config.inc.php');
require('./includes/header.php');
require(MYSQL);
require('./includes/sidebar.php');
redirect_invalid_user();
?>
<div id="content" class="column-right">
	<h3>Customer details:</h3>

	<h4>CustomerId:</h4>
	<p>
		<?php
		$userId = $_SESSION['user']->userId;
		echo "$userId";
		?>
	</p>
	<h4>Firstname:</h4>
	<p>
		<?php
		$firstname = $_SESSION['user']->firstName;
		echo "$firstname";
		?>
	</p>
	<h4>Lastname:</h4>
	<p>
		<?php
		$lastname = $_SESSION['user']->lastName;
		echo "$lastname";
		?>
	</p>
	<h4>Address:</h4>
	<p>
		<?php
		$address = $_SESSION['user']->address;
		echo "$address";
		?>
	</p>
</div>