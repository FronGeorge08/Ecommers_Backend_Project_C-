import React from "react";
import { AppBar, Toolbar, Box, Button, TextField, IconButton } from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import wazyLogo from "./wazy.png";

const Header = () => {
  return (
    <AppBar
      position="absolute"
      sx={{
        top: 0,
        left: 0,
        backgroundColor: "#e9fce1",
        height: "10vh",
        boxShadow: "none",
        border: "1px solid black",
        display: "flex",
        justifyContent: "center",
        padding: "10px",
        gap: "2vw",
        flexDirection: "row",
      }}
    >
      <Toolbar
        sx={{
          width: "100%",
          display: "flex",
          justifyContent: "space-between",
          padding: 0,
          gap: "2vw",
        }}
      >
        {/* Logo */}
        <Box
          sx={{
            width: "15vw",
            height: "10vh",
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          <Box
            component="img"
            src={wazyLogo}
            alt="logo"
            sx={{
              height: "13vh",
              width: "10vw",
              cursor: "pointer",
              pl: "15px",
            }}
          />
        </Box>

        {/* Search bar */}
        <Box
          sx={{
            display: "flex",
            alignItems: "center",
            justifyContent: "center",
            gap: "1vw",
            flexGrow: 1,
          }}
        >
          <TextField
            placeholder="Începe o nouă căutare"
            variant="outlined"
            size="small"
            sx={{
              height: "3vh",
              width: "50vw",
              "& .MuiInputBase-root": {
                height: "5vh",
                borderRadius: "0.5rem",
                fontSize: "1rem",
                backgroundColor: "white",
              },
            }}
          />
          <IconButton
            sx={{
              height: "5vh",
              width: "3vw",
              borderRadius: "5px",
              fontSize: "x-large",
              backgroundColor: "white",
              border: "1px solid black",
              transition: "background-color 0.5s",
              "&:hover": { backgroundColor: "lightblue" },
            }}
          >
            <SearchIcon />
          </IconButton>
        </Box>

        {/* Buttons */}
        <Box
          sx={{
            height: "10vh",
            display: "flex",
            alignItems: "center",
            justifyContent: "flex-end",
            gap: "2vw",
            mr: "5vw",
          }}
        >
          <Button
            sx={{
              height: "6vh",
              width: "8vw",
              backgroundColor: "#caf9b6",
              color: "white",
              fontSize: "x-large",
              border: "1px solid black",
              borderRadius: "5px",
              textTransform: "none",
              transition: "opacity 0.5s, color 0.5s",
              "&:hover": { opacity: 0.8, color: "black" },
              "&:active": { opacity: 0.5 },
            }}
          >
            Sign In
          </Button>
          <Button
            sx={{
              height: "6vh",
              width: "8vw",
              backgroundColor: "#00bfa6",
              color: "white",
              fontSize: "x-large",
              border: "1px solid black",
              borderRadius: "5px",
              textTransform: "none",
              transition:
                "opacity 0.5s, color 0.5s, border-radius 0.5s, background-color 0.5s",
              "&:hover": {
                opacity: 0.8,
                color: "lightgreen",
                backgroundColor: "#02dbbe",
                borderRadius: "50px",
              },
              "&:active": { opacity: 0.5 },
            }}
          >
            Get Started
          </Button>
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
