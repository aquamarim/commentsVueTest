<template>
    <div class="root">
        <div class="additionalInfo">
            <div>
                <p>
                <v-icon>
                    {{icons.mdiAccount}}
                </v-icon>
                {{name}}
            </p>
            </div>
            <v-spacer></v-spacer>
            <div>
                <p>
                    <v-icon>
                        {{icons.mdiMail}}
                    </v-icon>
                    E-Mail: {{mail}}
                </p>
            </div>
        </div>
        <v-divider></v-divider>
        <v-textarea label="Comment" readonly auto-grow v-bind:value="commentary">
            
        </v-textarea>
    </div>
</template>

<script>
import { mdiAccount, mdiMail } from '@mdi/js';
export default {
    props: {
        mail: String,
        name: String,
        commentary: String
    },
    data(){
        return {
            icons: {
                mdiAccount,
                mdiMail
            }
        }
    }
}
</script>

<style scoped>
.root{
    border: 2px solid gray;
    border-radius: 0.75rem;
    margin: 1rem 2rem;
}
.additionalInfo{
    margin: 5px;
    display: flex;
}
.additionalInfo div{
    margin-top: 10px;
}
.root .v-textarea{
    margin: 10px;
}
</style>
