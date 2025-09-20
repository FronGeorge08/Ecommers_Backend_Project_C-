import { Children } from "react";
import { Box, Card, CardContent, Typography, Button,TextField } from "@mui/material";

const ReusableForm = () => {

};
const Wrapper = ({ children }) => {
    return (
        <Box
            id="pageContainer_register"
            sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                height: "100vh",
                bgcolor: "#f3f4f6",
                fontFamily: "Arial, sans-serif",
            }}
        >
            <Card
                id="card_register"
                sx={{
                    maxWidth: 400,
                    width: "100%",
                    borderRadius: 3,
                    boxShadow: 3,
                    display: "flex",
                    flexDirection: "column",
                }}
            >
                <CardContent>
                    {children}
                </CardContent>
            </Card>
        </Box>
    );
};
const Header = ({ title }) => {
    return (
        <Typography
            id="formTitle_login"
            variant="h5"
            align="center"
            sx={{ mb: 3, fontWeight: "bold" }}
        >
            {title}
        </Typography>
    )
}
const Footer = ({ footerText }) => {
    return (
        <Box
            id="footer_register"
            sx={{
                borderTop: "1px solid #e0e0e0",
                mt: "auto",
                p: 2,
                textAlign: "center",
                bgcolor: "#f9f9f9",
                borderBottomLeftRadius: 12,
                borderBottomRightRadius: 12,
            }}
        >
            <Typography variant="body2" color="textSecondary">
                {footerText}
            </Typography>
        </Box>
    );
};
const IActionButton = ({ button_text, type }) => {
    return (
        <Button
            id="submitBtn_login"
            type={type}
            variant="contained"
            sx={{
                mt: 2,
                py: 1.5,
                fontWeight: "bold",
                borderRadius: 2,
                textTransform: "none",
            }}
        >
            {button_text}
        </Button>
    );
};
const Field = ({ id, name, label, type,...props}) => {
    return (
        <TextField
            id={id}
            name={name}
            label={label}
            type={type}
            {...props}
        />
    );
};
ReusableForm.Wrapper = Wrapper;
ReusableForm.Header = Header;
ReusableForm.Footer = Footer;
ReusableForm.Button = IActionButton;
ReusableForm.Field = Field;
export default ReusableForm;
