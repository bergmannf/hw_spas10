<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>
	<?php	if (isset ($page_title))
	{
		echo $page_title;
	}
	else {
		echo 'Macs bookstore';
	}
	?>
</title>
<link rel="stylesheet" type="text/css" href="css/styles.css" />
</head>
<body>
<div id="wrapper">
	<?php
	$pages = array(
	    'Home' => 'index.php',
	    'Products' => 'products.php',
	    'Shopping Cart' => 'shoppingcart.php',
	    'About' => 'about.php',
	    'Register' => 'register.php'
	);
	$this_page = basename($_SERVER['PHP_SELF']);
	echo '<div id="top" class="clear">';
	echo '<h1>Macs Bookstore</h1>';
	echo '<ul>';
	foreach ($pages as $k => $v)
	{
		echo '<li ';
		if ($this_page == $v)
		{
			echo 'class="selected"';
		}
		echo '><a href="'.$v.'"><span>',$k.'<span></a></li>';
	}
	echo '</ul>';
	echo '</div>'
	?>
	<div id="body" class="clear">