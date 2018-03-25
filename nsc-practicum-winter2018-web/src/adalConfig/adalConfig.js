import { AuthenticationContext, adalFetch} from 'react-adal';

export const adalConfig = {
 tenant: 'higheruppagmail.onmicrosoft.com',
 clientId: '5ea99641-000b-4756-a7df-9c750a20df6d', //currently set to localhost, change to  a974f648-59d8-4a23-a59c-83b20bce322a  for ustonboard.azurewebsites.net
 endpoints: {
   api: '5ea99641-000b-4756-a7df-9c750a20df6d',
 },
 cacheLocation: 'sessionStorage',
};

export const authContext = new AuthenticationContext(adalConfig);

export const adalApiFetch = (fetch, url, options) =>
 adalFetch(authContext, adalConfig.endpoints.api, fetch, url, options);

