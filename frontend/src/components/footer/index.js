import React from "react";
import { Box, Grid, Typography, Link, IconButton } from "@mui/material";
import FacebookIcon from "@mui/icons-material/Facebook";
import InstagramIcon from "@mui/icons-material/Instagram";
import RedditIcon from "@mui/icons-material/Reddit";
import EmailIcon from "@mui/icons-material/Email";
import PhoneIcon from "@mui/icons-material/Phone";
import wazyLogo from "./wazy.png";

const Footer = () => {
  return (
    <Box
      component="footer"
      sx={{
        bgcolor: "#ebf3bc",
        py: 4,
        px: 6,
        mt: "auto",
        borderTop: "1px solid #ccc",
      }}
    >
      <Grid
        container
        spacing={4}
        alignItems="center"
        justifyContent="space-between"
      >
        {/* Logo Section */}
        <Grid item xs={12} md={4} textAlign="center">
          <Box
            component="img"
            src={wazyLogo}
            alt="Wazy Logo"
            sx={{
              height: { xs: "60px", md: "80px" },
              cursor: "pointer",
            }}
          />
        </Grid>

        {/* About / Social Links */}
        <Grid item xs={12} md={4} textAlign="center">
          <Typography variant="h6" gutterBottom>
            About
          </Typography>
          <Box display="flex" justifyContent="center" gap={2}>
            <IconButton
              component={Link}
              href="https://www.facebook.com/?locale=ro_RO"
              target="_blank"
              color="inherit"
            >
              <FacebookIcon fontSize="large" />
            </IconButton>
            <IconButton
              component={Link}
              href="https://www.instagram.com"
              target="_blank"
              color="inherit"
            >
              <InstagramIcon fontSize="large" />
            </IconButton>
            <IconButton
              component={Link}
              href="https://www.reddit.com"
              target="_blank"
              color="inherit"
            >
              <RedditIcon fontSize="large" />
            </IconButton>
          </Box>
        </Grid>

        {/* Contact Section */}
        <Grid item xs={12} md={4} textAlign="center">
          <Typography variant="h6" gutterBottom>
            Contact Us
          </Typography>
          <Box display="flex" justifyContent="center" alignItems="center" gap={1}>
            <EmailIcon />
            <Typography variant="body1">contact@gmail.com</Typography>
          </Box>
          <Box display="flex" justifyContent="center" alignItems="center" gap={1}>
            <PhoneIcon />
            <Typography variant="body1">+40 748 797 946</Typography>
          </Box>
        </Grid>
      </Grid>

      {/* Bottom small text */}
      <Box mt={4} textAlign="center">
        <Typography variant="body2" color="text.secondary">
          © {new Date().getFullYear()} Wazy. All rights reserved.
        </Typography>
      </Box>
    </Box>
  );
};

export default Footer;
