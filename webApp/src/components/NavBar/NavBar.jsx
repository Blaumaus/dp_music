import React from "react";
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
import { useState } from 'react';
import useStyles from "./NavBar.styles"
import Icon from '@material-ui/core/Icon';
import PersonIcon from '@material-ui/icons/Person';
import ExitToAppIcon from '@material-ui/icons/ExitToApp';
import Avatar from '@material-ui/core/Avatar';
import * as Constants from 'constants/constants';
import { Link } from 'react-router-dom'

const logo = Constants.LOGO;

const NavBar = props => {

    const classes = useStyles();
    const { history } = props;
    //TODO: SetState use useEffect depends on token
    const [auth, setAuth] = useState(true);
    const [anchorEl, setAnchorEl] = useState(null);
    const open = Boolean(anchorEl);
    const theme = useTheme();
    const isMobile = useMediaQuery(theme.breakpoints.down("xs"));

    const handleMenu = event => {
        setAnchorEl(event.currentTarget);
    };

    const handleClick = (pageURL) => {
        history.push(pageURL);
        setAnchorEl(null);
    };

    return (
        <AppBar position="static" className={classes.root}>
            <Toolbar>
                <Avatar className={classes.avatar} src={logo} />
                <Typography variant="h6" className={classes.title}>
                    DP_Music
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
                                    <MenuItem component={Link} to="/SignIn" onClick={() => setAuth(false)}>SignOut</MenuItem>
                                    <MenuItem component={Link} to="/Profile">UserName</MenuItem>
                                </div>
                            ) : (
                                <div>
                                    <MenuItem component={Link} to="/SignIn">SignIn</MenuItem>
                                    <MenuItem component={Link} to="/SignUp">SignUp</MenuItem>
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
                                    onClick={() => setAuth(false)}
                                >
                                    SignOut
                                     </Button>

                            </div>
                        ) : (
                            <div className={classes.menuButtonMargin}>
                                <Button
                                    component={Link} to="/SignIn"
                                    variant="text"
                                    className={classes.menuButton}
                                >
                                    SignIn
                                     </Button>
                                <Button
                                    component={Link} to="/SignUp"
                                    variant="text"
                                    className={classes.menuButton}
                                >
                                    SignUp
                                     </Button>

                            </div>
                        )}
                    </div>
                )}
            </Toolbar>
        </AppBar>
    );

}
export default withRouter(NavBar);