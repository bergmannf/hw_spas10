<?php
require('./includes/config.inc.php');
require('./includes/header.php');
require(MYSQL);
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
	include './includes/login.inc.php';
}
require('./includes/sidebar.php');
?>
<div id="content" class="column-right">
	<h3>Welcome to the MACS bookstore</h3>

	<p>To use the webshop, please login utilizing the panel on the left side of the webpage.</p>
	<p>If you have no login, please consider to <a href="register.php">register</a> to use this service.</p>
</div>
<?php
require('./includes/footer.php');
?>