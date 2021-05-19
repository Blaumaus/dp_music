import React, { useEffect, useState } from "react";
import { useTheme } from "@material-ui/core/styles";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";
import IconButton from "@material-ui/core/IconButton";
import MenuIcon from "@material-ui/icons/Menu";
import MenuItem from "@material-ui/core/MenuItem";
import Menu from "@material-ui/core/Menu";
import Button from "@material-ui/core/Button";
import useMediaQuery from "@material-ui/core/useMediaQuery";
import { withRouter } from "react-router";
import useStyles from "./NavBar.styles"
import PersonIcon from '@material-ui/icons/Person';
import ExitToAppIcon from '@material-ui/icons/ExitToApp';
import Avatar from '@material-ui/core/Avatar';
import * as Constants from 'constants/constants';
import { Link } from 'react-router-dom';
import AuthenticationService from '../AuthenticationService'
import CssBaseline from '@material-ui/core/CssBaseline';

const logo = Constants.LOGO;

const NavBar = props => {

    const classes = useStyles();

    const [auth, setAuth] = useState(false);
    const [loading, setLoading] = useState(true);
    const [anchorEl, setAnchorEl] = useState(null);
    const open = Boolean(anchorEl);
    const theme = useTheme();
    const isMobile = useMediaQuery(theme.breakpoints.down("xs"));

    useEffect(() => {
        AuthenticationService.checkAuthenticated().then(data => { setAuth(data) })
        setLoading(false);
    }, []);

    const handleMenu = event => {
        setAnchorEl(event.currentTarget);
    };

    const handleSignOutClick = () => {
        AuthenticationService.signout();
        props.history.push('/SignIn');
    }

    return (
        <CssBaseline>
        <AppBar position="static" className={classes.root}>
            {!loading && (
                <Toolbar>
                    <Avatar className={classes.avatar} src={logo} />
                    <Typography variant="h6" className={classes.title}>
                        WebSpeak
                    </Typography>
                    {isMobile ? (
                        <div>
                            <IconButton
                                edge="start"
                                className={classes.menuButton}
                                color="inherit"
                                aria-label="menu"
                                onClick={handleMenu}
                            >
                                <MenuIcon />
                            </IconButton>
                            <Menu
                                id="menu-appbar"
                                anchorEl={anchorEl}
                                anchorOrigin={{
                                    vertical: "top",
                                    horizontal: "right"
                                }}
                                keepMounted
                                transformOrigin={{
                                    vertical: "top",
                                    horizontal: "right"
                                }}
                                open={open}
                                onClose={() => setAnchorEl(null)}
                            >
                                {auth ? (
                                    <div>
                                        <MenuItem component={Link} to="/SignIn" onClick={() => setAuth(false)}>Sign Out</MenuItem>                               
                                    </div>
                                ) : (
                                    <div>
                                        <MenuItem component={Link} to="/SignIn">SignIn</MenuItem>
                                        <MenuItem component={Link} to="/SignUp">Sign Up</MenuItem>
                                    </div>
                                )}

                            </Menu>
                        </div>
                    ) : (
                        <div className={classes.headerOptions}>
                            {auth ? (
                                <div className={classes.menuButtonMargin}>
                                    <Button
                                        component={Link} to="/Profile"
                                        variant="text"
                                        className={classes.menuButton}
                                        startIcon={<PersonIcon />}
                                    >
                                        UserName
                                     </Button>
                                    <Button
                                        component={Link} to="/SignIn"
                                        variant="text"
                                        className={classes.menuButton}
                                        endIcon={<ExitToAppIcon />}
                                        onClick={handleSignOutClick}
                                    >
                                        Sign Out
                                     </Button>

                                </div>
                            ) : (
                                <div className={classes.menuButtonMargin}>
                                    <Button
                                        component={Link} to="/SignIn"
                                        variant="text"
                                        className={classes.menuButton}
                                    >
                                        Sign In
                                     </Button>
                                    <Button
                                        component={Link} to="/SignUp"
                                        variant="text"
                                        className={classes.menuButton}
                                    >
                                        Sign Up
                                     </Button>

                                </div>
                            )}
                        </div>
                    )}
                </Toolbar>
            )}
        </AppBar>
        </CssBaseline>
    );
}
export default withRouter(NavBar);