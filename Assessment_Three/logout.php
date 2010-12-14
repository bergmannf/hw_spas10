<?php
include './includes/config.inc.php';
redirect_invalid_user();
$_SESSION = array();
session_destroy();
setcookie(session_name(), '', time() - 24800);
$page_title = 'Logout';
include MYSQL;
include './includes/header.php';
?>
<div id="content" class="column-right">
	<h3>
	Logged out
	</h3>
	<p>
	Thank you for using the MACS bookstore. We hoped you enjoyed your experience.
	</p>
</div>
<?php
include './includes/footer.php';
?>
