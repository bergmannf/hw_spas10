<div id="sidebar" class="column-left">
	<ul>
		<li>
			<h4>Account</h4>
			<?php if (isset($_SESSION['user'])) {
			?>
				<div class="title">
					<h4>Manage your account</h4>
				</div>
				<ul>
					<li>
						<a href="customer_details.php" title="Show your account details">Account details</a>
					</li>
					<!-- TODO: add change password function
     <li>
						<a href="change_password.php" title="Change password">Change password</a>
					</li>-->
					<li>
						<a href="logout.php" title="Logout">Logout</a>
					</li>
				</ul>
			<?php
			} else {
				require('includes/login_form.inc.php');
			}
			?>
		</li>
	</ul>
</div>